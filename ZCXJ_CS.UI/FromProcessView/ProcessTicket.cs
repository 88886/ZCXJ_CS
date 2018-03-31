using System;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace FromProcessView
{
    public partial class ProcessTicket : UserControl
    {
        //选中通知的委托
        public delegate void NotifySelectedDelegate(ProcessTicket item);
        //更改工单计划状态的委托
        public event NotifySelectedDelegate OnNotifySelected;
        private string path = Assembly.GetExecutingAssembly().Location;

        public ProcessTicket()
        {
            InitializeComponent();
        }
        public ProcessTicket(string index, string name, string time, string status)
        {
            InitializeComponent();

            SelfPath = Assembly.GetExecutingAssembly().Location;
            SelfPath = SelfPath.Substring(0, SelfPath.LastIndexOf('\\'));

            Index = index;
            ProcessName = name;
            ProcessTime = time;
            ProcessStatus = status;

            lblProcessIndex.Text = index;
            lblProcessName.Text = name;
            lblProcessTime.Text = time;
            if (status == "PASS")
            {
                picProcess.Load(SelfPath + "\\Res\\Pass.png");
            }
            else
            {
                picProcess.Load(SelfPath + "\\Res\\Fail.png");
            }
        }
        public string Index { get; set; }
        public string ProcessName { get; set; }
        public string ProcessTime { get; set; }
        public string ProcessStatus { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    this.BackColor = Color.SkyBlue; 
                }
                else
                {
                    this.BackColor = Color.Transparent; 
                }
            }
        }

        public string SelfPath;

        private void ProcessTicket_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设置选中状态
        /// </summary>SkyBlue
        /// <param name="isSel"></param>
        public void SetSelected(bool isSel)
        {
            _isSelected = isSel;
            if (_isSelected)
            {
                this.BackColor = Color.SkyBlue; 
                if (OnNotifySelected != null)
                {
                    OnNotifySelected(this);
                }
            }
            else
            {
                this.BackColor = Color.Transparent; 
            }
        }

        private void lblProcessName_Click(object sender, EventArgs e)
        {
            SetSelected(true);
        }
    }
}
