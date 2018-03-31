using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using ZCXJ_CS.Utilities;
using System.ComponentModel;

namespace ZCXJ_CS.Infrastructure
{
    /// <summary>
    /// 请求类型
    /// </summary>
    public enum RequestType
    {
        POST = 0,
        GET,
        PUT,
        DELETE
    }
    /// <summary>
    /// 传输参数对象
    /// </summary>
    public class PostDataParam
    {
        public string baseUrl;
        public string functionName;
        public RequestType type;
        public object requestData;
    }

    public delegate void DataTransCompletedDelegate(string data,object param);

    public class HttpDataTrans
    {
        private object Param { get; set; }
        /// <summary>
        /// Http Post完成
        /// </summary>
        public event DataTransCompletedDelegate OnDataTransCompleted;

        private static LogHelper log = LogHelper.GetInstence();
        private static ConfigHelper config = new ConfigHelper();

        /// <summary>
        /// 传输数据
        /// </summary>
        /// <param name="baseUrl">基url</param>
        /// <param name="functionName">调用方法名</param>
        /// <param name="type">请求类型</param>
        /// <param name="requestData">请求数据</param>
        /// <param name="param">回传参数</param>
        /// <returns></returns>
        public void DataTransAsyn(string baseUrl, string functionName, RequestType type, object requestData, object param = null)
        {
            Param = param;
            string ServerIP = config.GetKeyValue("ServerIP");
            string ServerPort = config.GetKeyValue("ServerPort");
            if (!string.IsNullOrEmpty(ServerIP) && !string.IsNullOrEmpty(ServerPort))
            {
                baseUrl = string.Format("http://{0}:{1}/{2}", ServerIP, ServerPort, baseUrl);
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.RunWorkerAsync(new PostDataParam { baseUrl = baseUrl, functionName = functionName, type = type, requestData = requestData });
            };
        }

        /// <summary>
        /// 传输数据
        /// </summary>
        /// <param name="baseUrl">基url</param>
        /// <param name="functionName">调用方法名</param>
        /// <param name="type">请求类型</param>
        /// <param name="requestData">请求数据</param>
        /// <returns></returns>
        public static string DataTrans(string baseUrl, string functionName, RequestType type, object requestData)
        {
            string result = string.Empty;
            string ServerIP = config.GetKeyValue("ServerIP");
            string ServerPort = config.GetKeyValue("ServerPort");
            if (!string.IsNullOrEmpty(ServerIP) && !string.IsNullOrEmpty(ServerPort))
            {
                baseUrl = string.Format("http://{0}:{1}/{2}", ServerIP, ServerPort, baseUrl);
                string uriStr = baseUrl + functionName;        //构造地址
                string data = JsonHelper.Serialize(requestData);
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uriStr));
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] bytes = encoding.GetBytes(data);
                    request.Method = type.ToString();
                    request.ContentType = "application/json";
                    request.Accept = "application/json;charset=utf-8";
                    request.ContentLength = bytes.Length;
                    request.Timeout = 10000;
                    Stream writeStream = request.GetRequestStream();
                    writeStream.Write(bytes, 0, bytes.Length);
                    writeStream.Close();
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, null);
                }
            }
            return result;
        }

        /// <summary>
        /// 异步数据传输
        /// </summary>
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            PostDataParam pdp = e.Argument as PostDataParam;
            string result = string.Empty;
            string uriStr = pdp.baseUrl + pdp.functionName;        //构造地址
            string data = JsonHelper.Serialize(pdp.requestData);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uriStr));
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(data);
                request.Method = pdp.type.ToString();
                request.ContentType = "application/json";
                request.Accept = "application/json;charset=utf-8";
                request.ContentLength = bytes.Length;
                request.Timeout = 10000;
                Stream writeStream = request.GetRequestStream();
                writeStream.Write(bytes, 0, bytes.Length);
                writeStream.Close();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            result = readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, null);
            }
            e.Result = result;        }

        /// <summary>
        /// 传输完成
        /// </summary>
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnDataTransCompleted != null)
            {
                OnDataTransCompleted(e.Result as string, Param);
            }
        }
    }
}
