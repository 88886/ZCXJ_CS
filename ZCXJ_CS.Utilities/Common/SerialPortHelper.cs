using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ZCXJ_CS.Utilities
{
    public class SerialPortHelper
    {
        //定义委托
        public delegate void DataReceivedDelegate(object sender, byte[] data);       
        //定义接收数据事件
        public event DataReceivedDelegate OnDataReceived;
        //通道（备用）
        public string Channel { get; set; }

        //是否忽略接收事件
        private bool ignoreReceiveEvent = false;
        //日志记录
        private LogHelper log = null;
        //内部SerialPort对象
        private SerialPort sp = null;

 
        /// <summary>
        /// 默认构造函数，操作COM1，波特率9600，没有奇偶校验，8位字节，停止位为1
        /// </summary>
        public SerialPortHelper()
            : this("COM1", 9600, Parity.None, 8, StopBits.One)
        {
        }
        
        /// <summary>
        /// 构造函数,可以自定义串口的初始化参数
        /// </summary>
        /// <param name="portName">需要操作的COM口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据长度</param>
        /// <param name="stopBits">停止位</param>
        public SerialPortHelper(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            sp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            Init();
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void Init()
        {
            if (sp != null)
            {
                //设置触发DataReceived事件的字节数为1
                sp.ReceivedBytesThreshold = 1;
                //接收到一个字节时，也会触发DataReceived事件
                sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                //接收数据出错,触发事件
                sp.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorReceivedHandler);
                //初始化日志记录对象
                log = LogHelper.GetInstence();
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public bool Open()
        {
            try
            {
                //打开串口
                sp.Open();
                if (sp.IsOpen)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            //如果串口处于打开状态,则关闭
            try
            {
                if (sp.IsOpen)
                    sp.Close();
            }
            catch (Exception)
            {
                
            }
        }

        /// <summary>
        /// 获取端口连接状态
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            //如果串口是打开的，true,否则为false;
            bool flag = false;
            try 
            { 
                flag = sp.IsOpen; 
            }
            catch
            {
            }
            return flag;

        }

        /// <summary>
        /// 获得当前电脑上的所有串口资源
        /// </summary>
        /// <returns>端口列表</returns>
        public static string[] GetPortList()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 获取串口名
        /// </summary>
        public string GetPortName()
        {
            return sp.PortName;
        }

        /// <summary>
        /// 接收串口数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //若忽略，则退出方法
            if (ignoreReceiveEvent) 
                return;
            //等待接收完全
            Thread.Sleep(100);
            int count = 0;
            List<byte> lstBytes = new List<byte>();
            while ((count = sp.BytesToRead) > 0)
            {
                byte[] buf = new byte[count];
                sp.Read(buf, 0, count);
                lstBytes.AddRange(buf);
                Thread.Sleep(5);
            }
            //通知其他模块
            if (OnDataReceived != null)
            {
                OnDataReceived(this, lstBytes.ToArray());
            }
        }

        /// <summary>
        /// 接收数据出错事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorReceivedHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            log.Error("串口数据接收发生错误：",e.EventType.ToString());
        }

        /// <summary>
        /// 串口数据发送
        /// </summary>
        /// <param name="data">发送数据为字符串</param>
        /// <param name="data">发送字符串的编码格式</param>
        public void SendData(string data, Encoding encoding)
        {
            if (sp.IsOpen)
            {
                byte[] buf = encoding.GetBytes(data);
                sp.Write(buf, 0, buf.Length);
            }
        }

        /// <summary>
        /// 串口数据发送
        /// </summary>
        /// <param name="data">发送数据为字节数组</param>
        public void SendData(byte[] data, int offset, int count)
        {
            if (sp.IsOpen)
            {
                sp.Write(data, offset, count);
            }
        }

        /// <summary>
        /// 串口数据发送
        /// </summary>
        /// <param name="data">发送数据为字节数组</param>
        public void SendData(byte[] data)
        {
            if (sp.IsOpen)
            {
                sp.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// 串口数据发送
        /// </summary>
        /// <param name="data">发送数据为字节数组</param>
        /// <param name="ms">超时等待的毫秒数</param>
        public byte[] SendDataWait(byte[] data, long ms)
        {
            List<byte> lstBytes = new List<byte>();
            if (sp.IsOpen)
            {
                //关闭接收事件
                ignoreReceiveEvent = true;
                //清空接收缓冲区
                sp.DiscardInBuffer();         
                sp.Write(data, 0, data.Length);

                long count = ms/10 + 1;
                for (int i = 0; i < count; i++)
                {                                          
                    if (sp.BytesToRead > 0)
                    {
                        Thread.Sleep(100);
                        while (sp.BytesToRead > 0)
                        {
                            byte[] buf = new byte[sp.BytesToRead];
                            sp.Read(buf, 0, sp.BytesToRead);
                            lstBytes.AddRange(buf);
                            Thread.Sleep(5);
                        }
                        break;
                    }
                    Thread.Sleep(10);
                }
            }
            return lstBytes.ToArray();
        }
    }
}
