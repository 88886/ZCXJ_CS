using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using ZCXJ_CS.Utilities;
using ZCXJ_CS.Applications;
using System.Diagnostics;


namespace ZCXJ_CS.UI
{
    public partial class FormTest : FormBase
    {
        
        ConfigHelper cfg = null;
        IOperation opt = null;
        string path = Assembly.GetExecutingAssembly().Location + ".config";
        
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest2_Load(object sender, EventArgs e)
        {
            cfg = new ConfigHelper(path);
            
        }

        public void ShowPic(int index)
        {
            if (index == 0)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
            }
            else if (index == 1)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
        }

        private void btnTest01_Click(object sender, EventArgs e)
        {
            string key = new StackTrace().GetFrame(0).GetMethod().Name;
            string optName = cfg.GetKeyValue(key);
            opt = OperationFactory.BulidOperation(optName);
            if (opt != null)
            {
                opt.Operate(this);
            }
        }

        private void btnTest02_Click(object sender, EventArgs e)
        {

        }

        private void btnTest03_Click(object sender, EventArgs e)
        {

        }

        private void btnTest04_Click(object sender, EventArgs e)
        {

        }

        private void btnTest05_Click(object sender, EventArgs e)
        {

        }

    }
}
