using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using ZCXJ_CS.UI;
using ZCXJ_CS.Applications;
using System.Reflection;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using MetroFramework.Forms;
using MetroFramework;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Presentation
{
    public partial class FormMain : MetroForm
    {
        #region /// <summary> 字段声明
        /// <summary>
        /// 插件容器
        /// </summary>
        private CompositionContainer _container;
        [ImportMany]
        public IEnumerable<IUIPlugin> UIPlugins;
        //插件图像列表
        public Dictionary<int, PictureBox> dicPicbox;
        //菜单tsBtn列表
        public Dictionary<int, ToolStripButton> dicToolStripButton;
        //插件列表
        public Dictionary<int, IUIPlugin> dicUIPlugins;
        //标识网络是否通畅
        public bool IsConnectionOK = false;
        //当前选中序号
        public int currentindex = -1;
        //可执行文件路径
        public string ExePath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }
        //计时数
        private long timeCounter = 0;
        //日志记录助手
        private LogHelper log;
        //配置文件助手
        private ConfigHelper cfgHelper;

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormMain()
        {
            //初始化界面控件
            InitializeComponent();


            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 在缓冲区重绘
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        /// <summary>
        /// 异步加载结束后更新界面
        /// </summary>
        private void AsyncLoadUIPlugunsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var keys = dicPicbox.Keys.OrderBy(i => i).ToList();
            int first = keys.Min();
            dicPicbox[first].Image = dicUIPlugins[first].SelectPluginPic;
            currentindex = first;
            foreach (var i in keys)
            {
                ToolStripButton tsb = new ToolStripButton();
                tsb.ImageScaling = ToolStripItemImageScaling.None;
                tsb.Image = dicUIPlugins[i].SelectPluginPic;
                tsb.Text = dicUIPlugins[i].PluginText;
                tsb.TextImageRelation = TextImageRelation.ImageAboveText;
                tsb.Click += (_sender, _e) =>
                {
                    if (currentindex != -1)
                    {
                        dicPicbox[currentindex].Image = dicUIPlugins[currentindex].PluginPic;
                    }
                    ShowUIPlugin(dicUIPlugins[i].PluginForm, true);
                    currentindex = i;
                };
                tsMainTop.Items.Add(tsb);
            }
            if (!FormBase.IsLoaddingShow)
            {
                ShowUIPlugin(dicUIPlugins[first].PluginForm, true);
                logText.Text = string.Empty;
            }
            log.Info("程序就绪...");
            log.Info("加载PalCode..." + GlobalData.PalCode);
        }

        /// <summary>
        /// 异步初始化UI插件
        /// </summary>
        private void AsyncLoadUIPluguns(object sender, DoWorkEventArgs e)
        {
            log.Info("正在加载模块插件...");
            //加载本地模块DLL
            InitUIPlugins();
            log.Info("正在初始化模块插件...");
            //初始化模块插件
            LoadUIPlugins();
        }
        /// <summary>
        /// 窗体载入
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            GlobalData.InitGlobalData();//初始化全局数据
            //设置界面元素
            logText.Text = "程序正在加载中,请稍后...";
            this.Text = string.Format("IA-MES CS端系统 ({0} - {1})", GlobalData.Process, GlobalData.MachineId);
            //pnlTitle.BackgroundImage = Image.FromFile(ExePath + @"Res\MainTitle_BK.png");
            //pnlTitle.BackgroundImageLayout = ImageLayout.Stretch;

            tsMainTop.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
            tsMainTop.Items.Clear();

            //pnlMainTop.BackgroundImage = Image.FromFile(ExePath + @"\Res\BarPanel.png");
            //pnlMainTop.BackgroundImageLayout = ImageLayout.Stretch;
            //staStripMain.BackgroundImage = Image.FromFile(ExePath + @"\Res\StripMain.png");
            //staStripMain.BackgroundImageLayout = ImageLayout.Stretch;
            //picLoginUser.Load(ExePath + @"Res\LoginUser.png");
            CenterImage.Image = Image.FromFile(ExePath + @"Res\Network2.png");
            staStripVersion.Text = "版本：" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            LogPictruce.Load(ExePath + @"Res\load.gif");
            FormBase.OnLoadingChange += OnFormLoadingChange;
            InitFormMainContext();
            //隐藏条码-日志窗口
            tabCtrlBottom.Visible = true;
            //启动网络连接监测线程
            Thread threadPing = new Thread(CheckNetConnection);
            threadPing.IsBackground = true;
            threadPing.Priority = ThreadPriority.Lowest;
            threadPing.Start(GlobalData.ServerIP);
        }
        /// <summary>
        /// 加载窗口内容
        /// </summary>
        private void InitFormMainContext()
        {
            cfgHelper = GlobalData.CfgHelper;
            log = GlobalData.Log;
            log.OnDisplayLog += OnDisplayLog;
            dicPicbox = new Dictionary<int, PictureBox>();
            dicToolStripButton = new Dictionary<int, ToolStripButton>();
            dicUIPlugins = new Dictionary<int, IUIPlugin>();

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += AsyncLoadUIPluguns;
            bgw.RunWorkerCompleted += AsyncLoadUIPlugunsCompleted;
            bgw.RunWorkerAsync();//开启异步加载插件模块
        }
        /// <summary>
        /// 初始化插件容器
        /// </summary>
        private void InitUIPlugins()
        {
            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog(Application.StartupPath + "\\Plugins\\UI\\"));
                _container = new CompositionContainer(catalog);
                this._container.ComposeParts(this);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 载入UI插件集合
        /// </summary>
        public void LoadUIPlugins()
        {
            if (UIPlugins == null)
                return;
            try
            {
                foreach (IUIPlugin plugin in UIPlugins)
                {
                    int index = 0;
                    int.TryParse(cfgHelper.GetKeyValue(plugin.PluginId), out index);
                    if (cfgHelper.IsKeyExists(plugin.PluginId)
                        && index > 0)
                    {
                        LoadUIPlugin(plugin, index);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        /// <summary>
        /// 初始化插件页及图标
        /// </summary>
        /// <param name="plugin">插件对象</param>
        /// <param name="index">插件序号</param>
        private void LoadUIPlugin(IUIPlugin plugin, int index)
        {
            PictureBox picture = new PictureBox();
            picture.BackColor = Color.Transparent;
            picture.Image = plugin.PluginPic;
            picture.InitialImage = null;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Size = new Size(66, 66);
            picture.Margin = new Padding(10, 2, 0, 0);
            picture.TabStop = false;
            dicPicbox.Add(index, picture);
            dicUIPlugins.Add(index, plugin);
            #region ***取消注释部分代码可预加载页面***
            //var iasync = tabCtrlMain.BeginInvoke(new Action(() =>
            //{
            //    ShowUIPlugin(plugin.PluginForm);
            //}));
            //while (!iasync.IsCompleted)
            //    Thread.Sleep(10);//等待加载结束，防止造成阻塞
            //Thread.Sleep(50);//防止主线程繁忙导致长时间假死现象
            #endregion
            //单击时切换至插件主界面
            picture.Click += (sender, e) =>
            {
                if (currentindex != -1)
                {
                    dicPicbox[currentindex].Image = dicUIPlugins[currentindex].PluginPic;
                }
                picture.Image = plugin.SelectPluginPic;
                ShowUIPlugin(plugin.PluginForm, true);
                currentindex = index;
            };
        }
        /// <summary>
        /// 加载插件主界面
        /// </summary>
        /// <param name="frm"></param>
        private void ShowUIPlugin(Form frm, bool isShow = false)
        {
            int index = tabCtrlMain.TabPages.IndexOfKey(frm.Name);
            if (index == -1)
            {
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowIcon = false;
                frm.ShowInTaskbar = false;
                //要将是否顶级控件设置为false，否则会报错
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                TabPage tabPage = new TabPage();
                tabPage.SuspendLayout();
                tabPage.Name = frm.Name;
                tabPage.Margin = tabPage.Padding = new Padding(0);
                tabPage.Controls.Add(frm);
                tabCtrlMain.TabPages.Add(tabPage);
                tabPage.ResumeLayout(false);
                tabPage.Show();
                frm.Show();
                index = tabCtrlMain.TabPages.IndexOf(tabPage);
            }
            if (isShow && index != -1)
            {
                tabCtrlMain.SelectedIndex = index;
            }
        }
        /// <summary>
        /// 加载页面状态改变
        /// </summary>
        /// <param name="IsShow">显示状态</param>
        private void OnFormLoadingChange(string frmName, string msg, bool IsShow)
        {
            this.Invoke(new Action(() =>
            {
                if (IsShow)
                {
                    logText.Text = msg;
                    tsMainTop.Enabled = false;
                    //pnlMainTop.Enabled = false;
                    if (tabCtrlMain.SelectedTab != LogPage)
                        tabCtrlMain.SelectedTab = LogPage;
                }
                else
                {
                    logText.Text = string.Empty;
                    tsMainTop.Enabled = true;
                    //pnlMainTop.Enabled = true;
                    if (tabCtrlMain.SelectedTab != tabCtrlMain.TabPages[frmName])
                        tabCtrlMain.SelectedTab = tabCtrlMain.TabPages[frmName];
                }
            }));
        }
        /// <summary>
        /// 使用ping检测网络是否通畅
        /// </summary>
        /// <param name="ip">被测主机IP地址</param>
        /// <returns></returns>
        private void CheckNetConnection(object obj)
        {
            object lockObj = new object();
            string ip = obj as string;
            Ping ping = new Ping();
            while (true)
            {
                try
                {
                    PingReply pingReply_Server = ping.Send(ip, 2000);
                    PingReply pingReply_Plc = ping.Send(GlobalData.PlcIP, 2000);
                    lock (lockObj)
                    {
                        if (pingReply_Plc.Status == IPStatus.Success && pingReply_Server.Status == IPStatus.Success)
                        {
                            IsConnectionOK = true;
                        }
                        else
                        {
                            IsConnectionOK = false;
                        }
                    }
                }
                catch (Exception)
                {
                    IsConnectionOK = false;
                }
                finally
                {
                    Thread.Sleep(2000);
                }
            }
        }
        /// <summary>
        /// 显示日志信息
        /// </summary>
        /// <param name="msg"></param>
        private void OnDisplayLog(string msg)
        {
            this.Invoke(new Action<string>((message) =>
            {
                rtbLog.AppendText(message);
                rtbLog.ScrollToCaret();
                message = message.Substring(message.IndexOf(">>") + 2);
                message = "信息：" + message.Substring(0, message.LastIndexOf('('));
                staStripNote.Text = message;
            }), msg);
        }
        /// <summary>
        /// 主界面定时器事件
        /// </summary>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            //更新时间
            staStripTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //更新当前操作工
            lblLoginUser.Text = "admin";
            //读SCADA数据
            if (timeCounter % 5 == 0)
            {
                //scada.ReadData();
            }
            //检查网络连接 
            if (timeCounter % 5 == 0)
            {
                if (IsConnectionOK != FormBase.IsNetConnected)
                {
                    if (IsConnectionOK)
                    {
                        CenterImage.Image = Image.FromFile(ExePath + @"Res\Network.png");
                    }
                    else
                    {
                        CenterImage.Image = Image.FromFile(ExePath + @"Res\Network2.png");
                    }
                    FormBase.IsNetConnected = IsConnectionOK;
                }
            }
            timeCounter++;
        }
        /// <summary>
        /// 状态条提示文字
        /// </summary>
        private void staStripNote_Click(object sender, EventArgs e)
        {
            staStripShowOutWnd_Click(null, null);
        }
        /// <summary>
        /// 显隐条码和日志窗口
        /// </summary>
        private void staStripShowOutWnd_Click(object sender, EventArgs e)
        {
            tabCtrlBottom.Visible = !tabCtrlBottom.Visible;
            if (tabCtrlBottom.Visible)
            {
                staStripShowOutWnd.Text = " ↓ [条码-日志]";
            }
            else
            {
                staStripShowOutWnd.Text = " ↑ [条码-日志]";
            }
        }
        /// <summary>
        /// 测试2
        /// </summary>
        private void staStripTest2_Click(object sender, EventArgs e)
        {
            //scada.WriteData("MES_Clean", 1);
            log.Debug("测试启动");
            //GlobalData.Scada.WriteData("MES_Clean", 1);
        }
        #region /// <summary> 退出处理
        /// <summary>
        /// 双击登录头像框，注销并弹出登录框
        /// </summary>
        private void picLoginUser_DoubleClick(object sender, EventArgs e)
        {
            //TODO
        }

        /// <summary>
        /// 双击登录用户名，注销并弹出登录框
        /// </summary>
        private void lblLoginUser_DoubleClick(object sender, EventArgs e)
        {
            //TODO
        }

        /// <summary>
        /// 双击标题栏图标，退出系统
        /// </summary>
        private void picMainIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblMainTitle_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 主窗口关闭处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "确定退出本系统吗", "退出系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //DialogResult dr = DlgBox.Show("确定退出本系统吗？", "退出系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                log.OnDisplayLog -= OnDisplayLog;
                FormBase.OnLoadingChange -= OnFormLoadingChange;
            }
        }

        #endregion 退出处理
        private void picNetwork_Click(object sender, EventArgs e)
        {
            MainSplit.Panel1Collapsed = !MainSplit.Panel1Collapsed;
            //pnlMainTop.Visible = !MainSplit.Panel1Collapsed
            tsMainTop.Visible = !MainSplit.Panel1Collapsed;

        }
        private void tabCtrlMain_SizeChanged(object sender, EventArgs e)
        {
            tabCtrlMain.Region = new Region(new RectangleF(0, 0, this.Width, tabCtrlMain.Height - 5));
        }
    }
}
