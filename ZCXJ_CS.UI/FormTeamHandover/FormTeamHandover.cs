using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using ZCXJ_CS.Utilities;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Applications;
using System.Linq;
using System.Diagnostics;

namespace ZCXJ_CS.UI
{
    public partial class FormTeamHandover : FormBase
    {
        public string PostsName = "";
        public string TeamHaType = "";
        public string TeamHaContent = "";
        public string StrID = "";
        public string[] post_names;
        public string teamcount;
        //TextBox tBoxLost_Foucs = new TextBox();
        //TextBox tBoxGet_Foucs = new TextBox();
        public ConfigHelper cfgHelper = null;
        public LogHelper log;
        public string[] str_hand = new string[] { }; //记录交班人员信息ID
        public string[] str_receive = new string[] { };  //记录接班人员信息ID
        public string[] str_handname = new string[] { }; //记录交班人员信息Name
        public string[] str_receivename = new string[] { };//记录接班人员信息Name
        public int State;//区分交接班按钮
        public IDBHelper IDBh = new SqliteHelper();
        public string MachineNo;
        public string ShiftName = "";
        TeamHandoverManager TmManager = null;

        //配置文件路径
        string cfgFile = Assembly.GetExecutingAssembly().Location + ".config";

        public FormTeamHandover()
        {
            InitializeComponent();
        }

        private void FormTeamHandover_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            cfgHelper = new ConfigHelper(cfgFile);
            PostsName = cfgHelper.GetKeyValue("岗位");
            TeamHaType = cfgHelper.GetKeyValue("交接班类型");
            TeamHaContent = cfgHelper.GetKeyValue("交接班记录");
            StrID = cfgHelper.GetKeyValue("工号");
            ShiftName = cfgHelper.GetKeyValue("班组");
            MachineNo = GlobalData.MachineId;
            TmManager = new TeamHandoverManager();

            if (TeamHaType == "0")
            {
                if (StrID != "")
                {
                    btn_receive.Visible = false;
                }
                labelreceive.Text = "下一班组:";
                //textBox_obtain.Visible = false;
                //btn_receive.Location = new Point(110, 33);
                //labelcont.Visible = false;
                cobreceive.Enabled = false;
                textBox_obtain.Enabled = false;

                //label3.Location = new Point(186, 38);
                //cobshift.Location = new Point(286, 33);
            }

            //加载Combox
            string[] post_content = TeamHaContent.Split(',');
            string[] receive_content = TeamHaContent.Split(',');
            cobpass.DataSource = post_content;
            cobreceive.DataSource = receive_content;

            string[] shift_name = ShiftName.Split(',');
            cobshift.DataSource = shift_name;

            textBox_shift.GotFocus += TBox_GotFocus;
            textBox_shift.LostFocus += TBox_LostFocus;
            textBox_obtain.GotFocus += TBox_GotFocus;
            textBox_obtain.LostFocus += TBox_LostFocus;


            // 注册扫码器
            GlobalData.SpScanner.OnDataReceived += serialport_OnDataReceived;
            log = LogHelper.GetInstence();
            //动态加载界面
            generateUI();
        }

        #region 扫码器冒泡事件
        void serialport_OnDataReceived(object sender, byte[] data)
        {
            string str = System.Text.Encoding.Default.GetString(data).Replace("\r\n","");//字节转换成字符串
            try
            {
                UpdateUI(str);
            }
            catch 
            {
                log.Info("扫描枪获取数据失败");
            }
        }
        #endregion

        #region 加载界面
        private void generateUI()
        {
            Dictionary<string, string> posts = new Dictionary<string, string>();
            string[] str_id = new string[] { };
            str_id = StrID.Split(',');
            post_names = PostsName.Split(',');
            int strlenth = post_names.Length;

            for (int i = 0; i < post_names.Length; i++)
            {
                posts.Add("post_" + (i + 1), post_names[i]);
            }
            int j = 0;
            foreach (var post in posts)
            {
                System.Windows.Forms.FlowLayoutPanel pan_pass1 = new System.Windows.Forms.FlowLayoutPanel();
                pan_pass1.FlowDirection = FlowDirection.LeftToRight;
                pan_pass1.Height = 50;
                pan_pass1.Width = 490;

                System.Windows.Forms.FlowLayoutPanel pan_obtain1 = new System.Windows.Forms.FlowLayoutPanel();
                pan_obtain1.FlowDirection = FlowDirection.LeftToRight;
                pan_obtain1.Height = 50;
                pan_obtain1.Width = 490;

                // 生成标签
                System.Windows.Forms.Label post_label1 = new System.Windows.Forms.Label();
                post_label1.Height = 30;
                post_label1.Width = 75;
                post_label1.Font = new Font("微软雅黑", 11);
                post_label1.Text = post.Value + ":";

                // 生成文本框
                System.Windows.Forms.TextBox post_tbox1 = new System.Windows.Forms.TextBox();
                post_tbox1.Height = 30;
                post_tbox1.Width = 200;
                post_tbox1.Multiline = false;
                //post_tbox1.Location = new Point(95, 0);
                post_tbox1.TextAlign = new HorizontalAlignment();
                //post_tbox1.ReadOnly = true;
                post_tbox1.Enabled = false;
                post_tbox1.Font = new Font("微软雅黑", 11);
                post_tbox1.Name = post.Key;
                post_tbox1.GotFocus += TBox_GotFocus;
                post_tbox1.LostFocus += TBox_LostFocus;
                post_tbox1.KeyDown += post_tbox1_KeyDown;
                if (StrID != "")
                {
                    post_tbox1.Text = QueryUser(str_id[j]);
                }

                // 生成按钮
                System.Windows.Forms.Button ChangeMem_btn1 = new System.Windows.Forms.Button();
                ChangeMem_btn1.Text = "换人";
                ChangeMem_btn1.Tag = post.Key;
                ChangeMem_btn1.Height = 30;
                ChangeMem_btn1.Width = 80;
                ChangeMem_btn1.FlatStyle = FlatStyle.Flat;
                ChangeMem_btn1.BackColor = Color.Transparent;
                ChangeMem_btn1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
                ChangeMem_btn1.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
                ChangeMem_btn1.FlatAppearance.BorderSize = 1;
                ChangeMem_btn1.FlatAppearance.BorderColor = Color.Black;
                //ChangeMem_btn1.Location = new Point(294, 3);
                ChangeMem_btn1.Font = new Font("微软雅黑", 11);
                ChangeMem_btn1.Click += new EventHandler(ChangeMem_btn1_Click);


                pan_pass1.Controls.Add(post_label1);
                pan_pass1.Controls.Add(post_tbox1);
                pan_pass1.Controls.Add(ChangeMem_btn1);
               

                // 生成标签
                System.Windows.Forms.Label post_label2 = new System.Windows.Forms.Label();
                post_label2.Height = 30;
                post_label2.Width = 75;
                post_label2.Font = new Font("微软雅黑", 11);
                //post_label2.Location = new Point(3, 0);
                post_label2.Text = post.Value + ":";

                // 生成文本框
                System.Windows.Forms.TextBox post_tbox2 = new System.Windows.Forms.TextBox();
                post_tbox2.Height = 30;
                post_tbox2.Width = 200;
                post_tbox2.Multiline = false;
                //post_tbox2.Location = new Point(95, 0);
                post_tbox2.TextAlign = new HorizontalAlignment();
                //post_tbox1.ReadOnly = true;
                //post_tbox1.Enabled = false;
                post_tbox2.Font = new Font("微软雅黑", 11);
                post_tbox2.Name = "N" + post.Key;
                post_tbox2.GotFocus += TBox_GotFocus;
                post_tbox2.LostFocus += TBox_LostFocus;
                post_tbox2.KeyDown += post_tbox1_KeyDown;

                pan_obtain1.Controls.Add(post_label2);
                pan_obtain1.Controls.Add(post_tbox2);

                panel_pass.Controls.Add(pan_pass1);
                panel_obtain.Controls.Add(pan_obtain1);

                j++;
            }
        }
        #endregion

        #region 更新界面
         private void UpdateUI(string code)
        {
            this.BeginInvoke( new Action(() =>
            {
                if (this.ActiveControl is System.Windows.Forms.TextBox)
                {
                    if (code.Substring(0,2) == "HC")
                    {
                        this.ActiveControl.Text = "";
                        this.ActiveControl.Text = QueryUser(code);

                    }
                    else
                    {
                        MessageBox.Show("无效的扫描，请扫描工牌！");
                    }
                }
            }));
        }
        #endregion

        #region 文本框事件
        private void TBox_GotFocus(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox)
            {
                System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
                //tBoxGet_Foucs = tBox;
               
                tBox.Tag = true;
                setBackground(tBox, Color.Orange);
            }
        }

        private void TBox_LostFocus(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBox)
            {
                System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;

                //tBoxLost_Foucs = tBox;

                setBackground(tBox, Color.White);
            }       
        }

        private void setBackground(Control item, Color color)
        {
            item.BackColor = color ;
        }
        #endregion

        #region 换人事件
        void ChangeMem_btn1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)panel_pass.Controls.Find(((System.Windows.Forms.Button)sender).Tag as string, true)[0];
            tBox.Enabled = true;
            
        }
        #endregion=

        #region 文本框按钮事件

        private void post_tbox1_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //tBox.Text = tBox.Text.Trim().ToUpper();

                    tBox.Text = QueryUser(tBox.Text);
                    break;
                case Keys.Escape:
                    tBox.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void textBox_shift_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //tBox.Text = tBox.Text.Trim().ToUpper();

                    tBox.Text = QueryUser(tBox.Text);
                    break;
                case Keys.Escape:
                    tBox.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void textBox_obtain_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //tBox.Text = tBox.Text.Trim().ToUpper();

                    tBox.Text = QueryUser(tBox.Text);
                    break;
                case Keys.Escape:
                    tBox.Text = "";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 接班
        private void btn_receive_Click(object sender, EventArgs e)
        {
            State = 0;
            string str_postN = "Npost_1";  //接班主手
            System.Windows.Forms.TextBox tBoxN = (System.Windows.Forms.TextBox)panel_obtain.Controls.Find(str_postN, true)[0];
            if (tBoxN.Text != "")
            {
                if (TeamHaType == "0")
                {
                    str_receivename = new string[] { };
                    string textcount = "";
                    string userid = "";
                    for (int i = 0; i < post_names.Length; i++)
                    {
                        string strN = "Npost_" + (i + 1);
                        Control[] ctls = panel_obtain.Controls.Find(strN, true);
                        textcount = textcount + ctls[0].Text + ",";

                    }
                    str_receivename = textcount.Substring(0, textcount.Length - 1).Split(',');
                    foreach (string item in str_receivename)
                    {
                        userid = userid + QueryUserID(item) + ",";
                    }
                    str_receive = userid.Substring(0, userid.Length - 1).Split(',');

                    BackgroundWorker bkw = new BackgroundWorker();
                    bkw.DoWork += new DoWorkEventHandler(bkw_DoWork);
                    bkw.RunWorkerAsync();
                    bkw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkw_RunWorkerCompleted);
                }
                else if (TeamHaType == "1")
                {
                    if (textBox_obtain.Text != "")
                    {
                        if (MessageBox.Show("是否确定接班？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            str_receivename = new string[] { };
                            string textcount = "";
                            string userid = "";
                            for (int i = 0; i < post_names.Length; i++)
                            {
                                string strN = "Npost_" + (i + 1);
                                Control[] ctls = panel_obtain.Controls.Find(strN, true);
                                textcount = textcount + ctls[0].Text + ",";

                            }
                            str_receivename = textcount.Substring(0, textcount.Length - 1).Split(',');
                            foreach (string item in str_receivename)
                            {
                                userid = userid + QueryUserID(item) + ",";
                            }
                            str_receive = userid.Substring(0, userid.Length - 1).Split(',');

                            BackgroundWorker bkw = new BackgroundWorker();
                            bkw.DoWork += new DoWorkEventHandler(bkw1_DoWork);
                            bkw.RunWorkerAsync();
                            bkw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkw1_RunWorkerCompleted);
                        }
                    }
                    else
                    {
                        MessageBox.Show("接班人员信息未填，本班无法接班！");
                        //FormSysMessage.ShowSuccessMsg("接班人员信息未填，本班无法接班！");
                    }
                }
            }
            else
            {
                MessageBox.Show("没有主手信息，无法接班！");
                //FormSysMessage.ShowSuccessMsg("接班人员信息未填，本班无法接班！");
            }

        }
        #endregion

        #region 交班
        private void btn_hand_Click(object sender, EventArgs e)
        {
            State = 1;
            string str_post = "post_1";   //交班主手
            string str_postN = "Npost_1";  //下一班主手
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)panel_pass.Controls.Find(str_post, true)[0];
            System.Windows.Forms.TextBox tBoxN = (System.Windows.Forms.TextBox)panel_obtain.Controls.Find(str_postN, true)[0];
            if (TeamHaType == "0")
            {
                if (tBoxN.Text != "")
                {
                    if (textBox_shift.Text != "")
                    {
                        if (MessageBox.Show("是否确定交班？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            //获取本班交班信息
                            str_handname = new string[] { };
                            string textcount = "";
                            string userid = "";
                            for (int i = 0; i < post_names.Length; i++)
                            {
                                string str = "post_" + (i + 1);
                                Control[] ctls = panel_pass.Controls.Find(str, true);
                                textcount = textcount + ctls[0].Text + ",";

                            }
                            str_handname = textcount.Substring(0, textcount.Length - 1).Split(',');
                            foreach (string item in str_handname)
                            {
                                userid = userid + QueryUserID(item) + ",";
                            }
                            str_hand = userid.Substring(0, userid.Length - 1).Split(',');

                            //获取下一班接班信息
                            str_receivename = new string[] { };
                            string textcount1 = "";
                            string userid1 = "";
                            for (int i = 0; i < post_names.Length; i++)
                            {
                                string strN = "Npost_" + (i + 1);
                                Control[] ctls = panel_obtain.Controls.Find(strN, true);
                                textcount1 = textcount1 + ctls[0].Text + ",";

                            }
                            str_receivename = textcount1.Substring(0, textcount1.Length - 1).Split(',');
                            foreach (string item in str_receivename)
                            {
                                userid1 = userid1 + QueryUserID(item) + ",";
                            }
                            str_receive = userid1.Substring(0, userid1.Length - 1).Split(',');

                            BackgroundWorker bkw = new BackgroundWorker();
                            bkw.DoWork += new DoWorkEventHandler(bkw_DoWork);
                            bkw.RunWorkerAsync();
                            bkw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkw_RunWorkerCompleted);
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("当前班组交班人员信息未填，本班无法交班！");
                        //FormSysMessage.ShowSuccessMsg("当前班组交班人员信息未填，本班无法交班！");
                    }
                }
                else
                {
                    MessageBox.Show("下一班主手未预接班，本班无法交班！");
                    //FormSysMessage.ShowSuccessMsg("下一班主手未预接班，本班无法交班！");
                }
            }
            else if (TeamHaType == "1")
            {
                if (tBox.Text != "")
                {
                    if (textBox_shift.Text != "")
                    {
                        if (MessageBox.Show("是否确定交班？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            //获取本班交班信息
                            str_handname = new string[] { };
                            string textcount = "";
                            string userid = "";
                            for (int i = 0; i < post_names.Length; i++)
                            {
                                string str = "post_" + (i + 1);
                                Control[] ctls = panel_pass.Controls.Find(str, true);
                                textcount = textcount + ctls[0].Text + ",";

                            }
                            str_handname = textcount.Substring(0, textcount.Length - 1).Split(',');
                            foreach (string item in str_handname)
                            {
                                userid = userid + QueryUserID(item) + ",";
                            }
                            str_hand = userid.Substring(0, userid.Length - 1).Split(',');

                            //获取下一班接班信息
                            str_receivename = new string[] { };
                            string textcount1 = "";
                            string userid1 = "";
                            for (int i = 0; i < post_names.Length; i++)
                            {
                                string strN = "Npost_" + (i + 1);
                                Control[] ctls = panel_obtain.Controls.Find(strN, true);
                                textcount1 = textcount1 + ctls[0].Text + ",";

                            }
                            str_receivename = textcount1.Substring(0, textcount1.Length - 1).Split(',');
                            foreach (string item in str_receivename)
                            {
                                userid1 = userid1 + QueryUserID(item) + ",";
                            }
                            str_receive = userid1.Substring(0, userid1.Length - 1).Split(',');
                            BackgroundWorker bkw = new BackgroundWorker();
                            bkw.DoWork += new DoWorkEventHandler(bkw1_DoWork);
                            bkw.RunWorkerAsync();
                            bkw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkw1_RunWorkerCompleted);
                        }
                    }
                    else
                    {
                        MessageBox.Show("当前班组交班人员信息未填，本班无法交班！");
                        //FormSysMessage.ShowSuccessMsg("当前班组交班人员信息未填，本班无法交班！");
                    }
                }
                else
                {
                    MessageBox.Show("没有主手信息，无法交班！");
                    //FormSysMessage.ShowSuccessMsg("没有主手信息，无法交班！");
                }
              
            }
        }
        #endregion

        #region 交接班事件
        //TeamHaType == "0"
        void bkw_DoWork(object sender, DoWorkEventArgs e)
        {

            int strlenth = str_receive.Length;

            for (int i = 0; i < strlenth; i++)
            {
                string str_post = "post_" + (i + 1);
                string str_postN = "Npost_" + (i + 1);
                System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)panel_pass.Controls.Find(str_post, true)[0];
                System.Windows.Forms.TextBox tBoxN = (System.Windows.Forms.TextBox)panel_obtain.Controls.Find(str_postN, true)[0];

                tBox.Enabled = false;
                tBox.Text = tBoxN.Text;
                tBoxN.Text = "";
               
            }
            btn_receive.Visible = false;

            #region 插入交接班记录
            try
            {
                switch (State)
                {
                    case 0://接班记录

                        string id = "";
                        string name = "";
                        foreach (string item in str_receive)
                        {
                            id=id+item+",";
                        }
                        foreach (string item in str_receivename)
                        {
                            name = name + item + ",";
                        }
                        TeamHandover model = new TeamHandover();
                        model.handoverTime = DateTime.Now;
                        model.receiveTime = DateTime.Now;
                        model.planHandoverTime = DateTime.Now;
                        model.planReceiveTime = DateTime.Now;
                        model.receiveTeamLeader = str_receive[0];
                        model.receiveLeaderName = str_receivename[0];
                        model.receivePersons = id.Substring(0,id.Length-1);
                        model.receivePersonsName = name.Substring(0, name.Length - 1);
                        model.machineNo = MachineNo;
                        switch (cobshift.Text)
	                    {
                            case "甲班":
                                model.handTeamNo = "001";
                                model.receiveTeamNo = "001";
                                break;
                            case "乙班":
                                model.handTeamNo = "002";
                                model.receiveTeamNo = "002";
                                break;
                            case "丙班":
                                model.handTeamNo = "003";
                                model.receiveTeamNo = "003";
                                break;
                            case "丁班":
                                model.handTeamNo = "004";
                                model.receiveTeamNo = "004";
                                break;
		                    default:
                                break;
	                    }
                        model.handShift = cobshift.Text;
                        model.receiveShift = cobshift.Text;

                        //model.shiftId = model.receiveTeamLeader;
                        TeamHandoverManager um = new TeamHandoverManager();
                        um.Add(model);
                        break;

                    case 1://更新交班记录同时插入下个班接班记录
                        //ComboBox comBox = (ComboBox)panel_pass.Controls.Find("cobcontent", true)[0];
                        string receiveID = "";
                        string receiveName = "";
                        string handID = "";
                        string handName = "";

                        foreach (string item in str_hand)
                        {
                            handID = handID + item + ",";
                        }
                        foreach (string item in str_handname)
                        {
                            handName = handName + item + ",";
                        }
                        List<TeamHandover> list_hand = new List<TeamHandover>();
                        TeamHandoverManager um_hand = new TeamHandoverManager();
                        int listlenth;
                        list_hand = um_hand.GetList(-7);
                        listlenth = list_hand.Count;
                        list_hand[listlenth - 1].handoverTime = DateTime.Now;
                        list_hand[listlenth - 1].planHandoverTime = DateTime.Now;
                        list_hand[listlenth - 1].handTeamLeader = QueryUserID(textBox_shift.Text.Trim());
                        list_hand[listlenth - 1].handPersons = handID.Substring(0, handID.Length - 1);
                        list_hand[listlenth - 1].describe = cobpass.Text;
                        list_hand[listlenth - 1].handLeaderName = textBox_shift.Text.Trim();
                        list_hand[listlenth - 1].handPersonsName = handName.Substring(0, handName.Length - 1);
                        um_hand.Update(list_hand[listlenth - 1]);

                        DoQuery();

                        foreach (string item in str_receive)
                        {
                            receiveID = receiveID + item + ",";
                        }
                        foreach (string item in str_receivename)
                        {
                            receiveName = receiveName + item + ",";
                        }
                        TeamHandover model_receive = new TeamHandover();
                        model_receive.handoverTime = DateTime.Now;
                        model_receive.receiveTime = DateTime.Now;
                        model_receive.planHandoverTime = DateTime.Now;
                        model_receive.planReceiveTime = DateTime.Now;
                        //model_receive.shiftId = (int.Parse(list_hand[listlenth - 1].shiftId) + 1).ToString();
                        model_receive.receiveTeamLeader = str_receive[0];
                        model_receive.receiveLeaderName = str_receivename[0];
                        model_receive.receivePersons = receiveID.Substring(0, receiveID.Length - 1);
                        model_receive.receivePersonsName = receiveName.Substring(0, receiveName.Length - 1);
                        model_receive.machineNo = MachineNo;

                        switch (cobshift.Text)
	                    {
                            case "甲班":
                                model_receive.handTeamNo = "001";
                                model_receive.receiveTeamNo = "001";
                                break;
                            case "乙班":
                                model_receive.handTeamNo = "002";
                                model_receive.receiveTeamNo = "002";
                                break;
                            case "丙班":
                                model_receive.handTeamNo = "003";
                                model_receive.receiveTeamNo = "003";
                                break;
                            case "丁班":
                                model_receive.handTeamNo = "004";
                                model_receive.receiveTeamNo = "004";
                                break;
		                    default:
                                break;
	                    }
                        model_receive.handShift = cobshift.Text;
                        model_receive.receiveShift = cobshift.Text;
                        TeamHandoverManager um_receive = new TeamHandoverManager();
                        um_receive.Add(model_receive);
                        //更新全局用户对象
                        UpdateCurUser();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Info("", ex);
            }

            #endregion
        }
        //TeamHaType == "1"
        void bkw1_DoWork(object sender, DoWorkEventArgs e)
        {

            int strlenth = str_receive.Length;

            for (int i = 0; i < strlenth; i++)
            {
                string str_post = "post_" + (i + 1);
                string str_postN = "Npost_" + (i + 1);
                System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)panel_pass.Controls.Find(str_post, true)[0];
                System.Windows.Forms.TextBox tBoxN = (System.Windows.Forms.TextBox)panel_obtain.Controls.Find(str_postN, true)[0];

                tBox.Enabled = false;
                tBox.Text = tBoxN.Text;
                tBoxN.Text = "";

            }
            #region 插入交接班记录
            try
            {
                switch (State)
                {
                    case 0://接班记录

                        string id = "";
                        string name = "";
                        foreach (string item in str_receive)
                        {
                            id = id + item + ",";
                        }
                        foreach (string item in str_receivename)
                        {
                            name = name + item + ",";
                        }

                        List<TeamHandover> list = new List<TeamHandover>();
                        TeamHandoverManager um = new TeamHandoverManager();
                        int lenth;
                        list = um.GetList(-7);
                        lenth = list.Count;

                        TeamHandover model = new TeamHandover();
                        model.handoverTime = DateTime.Now;
                        model.receiveTime = DateTime.Now;
                        model.planHandoverTime = DateTime.Now;
                        model.planReceiveTime = DateTime.Now;
                        model.receiveTeamLeader = QueryUserID(textBox_obtain.Text.Trim());
                        model.receivePersons = id.Substring(0, id.Length - 1);
                        model.receiveLeaderName = textBox_obtain.Text.Trim();
                        model.receivePersonsName = name.Substring(0, name.Length - 1);
                        //if (lenth == 0)
                        //{
                        //    model.shiftId = "1";
                        //}
                        //else
                        //{
                        //    model.shiftId = (int.Parse(list[lenth - 1].shiftId) + 1).ToString();
                        //}

                        switch (cobshift.Text)
	                    {
                            case "甲班":
                                model.handTeamNo = "001";
                                model.receiveTeamNo = "001";
                                break;
                            case "乙班":
                                model.handTeamNo = "002";
                                model.receiveTeamNo = "002";
                                break;
                            case "丙班":
                                model.handTeamNo = "003";
                                model.receiveTeamNo = "003";
                                break;
                            case "丁班":
                                model.handTeamNo = "004";
                                model.receiveTeamNo = "004";
                                break;
		                    default:
                                break;
	                    }
                        model.handShift = cobshift.Text;
                        model.receiveShift = cobshift.Text;
                        
                        model.Remark = cobreceive.Text;
                        model.machineNo = MachineNo;
                        TeamHandoverManager um_receive = new TeamHandoverManager();
                        um_receive.Add(model);
                        //更新全局用户对象
                        UpdateCurUser();
                        break;

                    case 1://更新交班记录
                        //ComboBox comBox = (ComboBox)panel_pass.Controls.Find("cobcontent", true)[0];
                        string handID = "";
                        string handName = "";
                        foreach (string item in str_hand)
                        {
                            handID = handID + item + ",";
                        }
                        foreach (string item in str_handname)
                        {
                            handName = handName + item + ",";
                        }
                        List<TeamHandover> list_hand = new List<TeamHandover>();
                        TeamHandoverManager um_hand = new TeamHandoverManager();
                        int listlenth;
                        list_hand = um_hand.GetList(-7);
                        listlenth = list_hand.Count;
                        list_hand[listlenth - 1].handoverTime = DateTime.Now;
                        list_hand[listlenth - 1].planHandoverTime = DateTime.Now;
                        list_hand[listlenth - 1].handTeamLeader = QueryUserID(textBox_shift.Text.Trim());
                        list_hand[listlenth - 1].handPersons = handID.Substring(0, handID.Length - 1);
                        list_hand[listlenth - 1].describe = cobpass.Text;
                        list_hand[listlenth - 1].handLeaderName = textBox_shift.Text.Trim();
                        list_hand[listlenth - 1].handPersonsName = handName.Substring(0, handName.Length - 1);
                        um_hand.Update(list_hand[listlenth - 1]);

                        DoQuery();

                        break;

                    default:
                        break;
                }
            }

            catch (Exception ex)
            {
                log.Info("", ex);
            }

            #endregion



        }
        #endregion

        #region 线程完成事件
        //TeamHaType == "0"
        void bkw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //更新当前交接和接班人员记录信息
        {
            Remove();
            textBox_shift.Text = "";
        }
        //TeamHaType == "1"
        void bkw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //更新当前交接和接班人员记录信息
        {
            Remove();
            textBox_shift.Text = "";
            textBox_obtain.Text = "";
            cobpass.Text = "";
            cobreceive.Text = "";
        }
        #endregion

        #region 查询人员信息
        private string QueryUser(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return "";
            User user = new User();
            UserManager um = new UserManager();
            try
            {
                user = um.GetUser(code);
                if (user == null || string.IsNullOrEmpty(user.userName)) //BS端同步
                {
                    //TODO
                    string url = GlobalData.CfgHelper.GetKeyValue("API_QueryUser");
                    var requestData = new
                    {
                        userIds = code,
                        isCardNo = 1
                    };
                    string json = HttpDataTrans.DataTrans(url, "", RequestType.POST, requestData);
                    List<User> userlst = JsonResult<List<User>>.ConvertToModel(json);
                    if(userlst==null||userlst.Count==0)
                    {
                            json = HttpDataTrans.DataTrans(url, "", RequestType.POST, new {
                            userIds = code,
                            isCardNo = 0
                        });
                        if (string.IsNullOrWhiteSpace(json))
                        {
                            log.Error("拉取人员信息失败！");
                            MessageBox.Show("拉取人员信息失败，请联系管理员！");
                        }
                        else
                        {
                            userlst = JsonResult<List<User>>.ConvertToModel(json);
                        }
                    }
                    if (userlst.Count > 0)
                        user = userlst[0];
                    um.Add(user);
                }
            }
            catch { user = new User(); user.userName = ""; }
            return user.userName;
        }

        private string QueryUserID(string str_name)
        {
            string JN_str = "";
            UserManager um = new UserManager();
            try
            {
                JN_str = um.GetID(str_name).userId;
            }

            catch
            {
                return JN_str;
            }

            return JN_str;

        }
        #endregion

        #region 写入配置文件
        private void Remove()                                      
        {
            try
            {
                string id = "";
                foreach (string item in str_hand)
                {
                    id = id + item + ",";
                }
                if (id != "")
                {
                    cfgHelper.SaveKeyValue("工号", id.Substring(0, id.Length - 1));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 查看交接班详细
        private void btnQueryHistory_Click(object sender, EventArgs e)
        {
            LoadDataViewList();
        }
        /// <summary>
        /// 加载交接班记录列表框
        /// </summary>
        private void LoadDataViewList()
        {
            DlgBase dlg = new DlgBase();
            dlg.Text = "交接班信息查看";
            dlg.Size = new Size(900, 500);
            ListGridView<TeamHandoverView> gridview = new ListGridView<TeamHandoverView>();
            gridview.Dock = DockStyle.Fill;
            gridview.PageSize = 10;
            gridview.AllowUserToAddRows = false;
            gridview.GridView.AllowUserToResizeRows = false;
            gridview.Captions = TeamHandoverView.GetCaptions();
            gridview.ReadOnly = true;
            gridview.Dock = DockStyle.Fill;
            gridview.GridView.BackgroundColor = SystemColors.Control;
            gridview.DataBindingComplete += Gridview_DataBindingComplete;
            gridview.DataList = TmManager.GetTeamHandoverRecords();
            gridview.DataRefresh();
            dlg.BaseMainPanel.Controls.Add(gridview);
            dlg.BottomPane.Controls.Add(dlg.GenComandBtn("确认", "Ok", 1, null, DialogResult.OK));
            dlg.ShowDialog();
        }

        private void Gridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView datagv = sender as DataGridView;
            datagv.Columns["receiveTime"].Width = 100;
            datagv.Columns["handoverTime"].Width = 100;
            datagv.Columns["receivePersonsName"].Width = 150;
            datagv.Columns["handPersonsName"].Width = 150;
        }
        #endregion

        #region 操作班产和上传信息
        private void DoQuery()
        {
            #region 获取当班产量
            //IDBh.ChangeConnString("Data Source = MES_HX.db3");
            //string cmdText1 = "select * FROM T_PT_SCADA ";
            //DataRow dr = IDBh.GetDataRow(cmdText1);
            //teamcount = dr["Value"].ToString();

            //#endregion

            //#region 班产清零

            //try
            //{
            //    //TODO
            //    IDBh.ChangeConnString("Data Source = MES_HX.db3");
            //    string cmdText = "update T_PT_SCADA set Value=1 where Tagname='MES_Clean'";
            //    int comstate = IDBh.ExecuteNonQuery(cmdText);
            //    if (comstate != -1)
            //    {
            //        log.Info("成功清除班产！");
            //    }
            //    else
            //    {
            //        log.Info("清除班产失败！");
            //    }
            //}

            //catch (Exception ex)
            //{
            //    log.Info("清除班产失败！", ex);
            //}
            GlobalData.Scada.WriteData("MES_Clean", 1);

            #endregion


            #region 上传交接班信息至BS端

            //TODO
            try
            {
                TeamHandoverManager tm = new TeamHandoverManager();
                TeamHandover model = new TeamHandover();
                List<TeamHandover> list= new List<TeamHandover>();
                int listlenth;
                list = tm.GetList(-7);
                listlenth = list.Count;
                model = list[listlenth - 1];

                string url = GlobalData.CfgHelper.GetKeyValue("API_UpTeamHandover");
                var requestData = new
                {
                    machineNo = model.machineNo,
                    handoverTime = model.handoverTime,
                    handTeamLeader = model.handTeamLeader,
                    handTeamNo = model.handTeamNo,
                    handPersons = model.handPersons,
                    handShift = model.handShift,
                    receiveTeamLeader = model.receiveTeamLeader,
                    receiveTeamNo = model.receiveTeamNo,
                    receiveShift = model.receiveShift,
                    receivePersons = model.receivePersons,
                    describe = model.describe
                };
                string json = HttpDataTrans.DataTrans(url, "", RequestType.POST, requestData);
                if (string.IsNullOrWhiteSpace(json))
                {
                    log.Error("上传交接班数据失败！");
                    MessageBox.Show("上传交接班数据失败，请联系管理员！");
                }

            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// 更新全局用户对象
        /// </summary>
        private void UpdateCurUser()
        {
            GlobalData.CurUser.Clear();
            GlobalData.CurUser.userId = str_receive[0];
            GlobalData.CurUser.userName = str_receivename[0];
        }

    }
}
