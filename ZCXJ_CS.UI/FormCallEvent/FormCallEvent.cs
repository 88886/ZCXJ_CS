using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ZCXJ_CS.Utilities;
using System.Windows.Forms;
using System.Windows;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Domain;
using FormCallEvent;
using System.Reflection;
//using ZCXJ_CS.Infrastructure.DAL;

namespace ZCXJ_CS.UI
{
    public partial class FormCallEvent : FormBase
    {
        public List<ItemCallEvent> itemCEList;
        public List<CallEvent> ceList;
        public string CallType;
        public ConfigHelper cfgHelper = null;
        CallEventManager ceManager = new CallEventManager();
        public string[] str_type;
        //配置文件路径
        string cfgFile = Assembly.GetExecutingAssembly().Location + ".config";

        public FormCallEvent()
        {
            InitializeComponent();
            cfgHelper = new ConfigHelper(cfgFile);
            itemCEList = new List<ItemCallEvent>();
            ceList = new List<CallEvent>();
            CallType = cfgHelper.GetKeyValue("CallType");
            str_type = CallType.Split(',');
            foreach(string type in str_type)
            {
                tableLP.Controls.Add(GetButton(type, type, btncall_Click));
            }
            tableLP.Controls.Add(GetButton("重新载入", "Refresh", Refresh_Click));
        }
        private void FormCallEvent_Load(object sender, EventArgs e)
        {
            Refresh_Click(null, null);
        }
        /// <summary>
        /// 生产命令按钮
        /// </summary>
        /// <param name="Text">文本</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public Button GetButton(string Text,string Name, EventHandler Click)
        {
            Button btn = new Button();
            btn.Name = Name;
            btn.Text = Text;
            btn.Click += Click;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.Dock = System.Windows.Forms.DockStyle.Fill;
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn.ForeColor = System.Drawing.Color.Black;
            btn.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            return btn;
        }
        /// <summary>
        /// 新增呼叫
        /// </summary>
        void btncall_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            CallEvent model = new CallEvent();
            model.eventNo = ceManager.CallID(ceList);
            model.callType = str_type.ToList().IndexOf(btn.Name);
            model.eventstateName = btn.Text;
            CallEventDetail chw_call = new CallEventDetail(model);
            chw_call.State = 0;
            if (chw_call.ShowDialog() == DialogResult.OK)
            {
                ItemCallEvent item = new ItemCallEvent(model);
                item.OnCallSelected += OnItemSelected;
                itemCEList.Insert(0, item);
                tableLayList.Controls.Add(item, 0, 0);
            };
            ceList.Add(model);
        }
        /// <summary>
        /// 刷新事件
        /// </summary>
        void Refresh_Click(object sender, EventArgs e)
        {
            tableLayList.Controls.Clear();
            for (int i = 0; i < itemCEList.Count; i++)
            {
                itemCEList[i].OnCallSelected -= OnItemSelected;
                itemCEList[i].Dispose();
            }
            itemCEList.Clear();
            LoadCallEventList();
        }

        #region 加载事件控件
        private void LoadCallEventList()
        {
            ceList.Clear();
            ceList = ceManager.GetList("全部");
            for (int i = 0; i < ceList.Count; i++)
            {
                ItemCallEvent item = new ItemCallEvent(ceList[i]);
                item.OnCallSelected += OnItemSelected;
                itemCEList.Add(item);
            }
            tableLayList.Controls.AddRange(itemCEList.ToArray());
        }
        #endregion

        /// <summary>
        /// 列表中项目的选中状态处理
        /// </summary>
        /// <param name="itemWT"></param>
        private void OnItemSelected(ItemCallEvent itemWT)
        {
            //设置所有非选中项目
            for (int i = 0; i < itemCEList.Count; i++)
            {
                if (itemCEList[i] != itemWT)
                {
                    itemCEList[i].SetSelected(false);
                }
            }
        }
    }
}
