using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.Composition;
using System.Reflection;

namespace ZCXJ_CS.UI
{
    [Export(typeof(IUIPlugin))]
    public class FormTestPlugin : IUIPlugin
    {
        public FormBase PluginForm
        {
            get { return new FormTest(); }
        }

        public Image PluginPic
        {
            get { return Image.FromFile(PluginPath + "\\Res\\测试.png"); }
        }

        public Image SelectPluginPic
        {
            get { return Image.FromFile(PluginPath + "\\Res\\S测试.png"); }
        }
        public virtual string PluginId
        {
            get { return this.GetType().FullName; }
        }

        public virtual string PluginPath
        {
            get
            {
                string SelfPath = Assembly.GetExecutingAssembly().Location;
                SelfPath = SelfPath.Substring(0, SelfPath.LastIndexOf('\\'));
                return SelfPath;
            }
        }

        public string PluginText
        {
            get
            {
                return "测试";
            }
        }
    }
}
