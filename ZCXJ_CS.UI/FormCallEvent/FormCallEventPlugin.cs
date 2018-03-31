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
    public class FormCallEventPlugin : IUIPlugin
    {
        private FormBase _pluginForm = null;
        private Image _pluginPic = null;
        private Image _selectPluginPic = null;
        public FormBase PluginForm
        {
            get
            {
                if (_pluginForm == null)
                    _pluginForm = new FormCallEvent();
                return _pluginForm;
            }
        }

        public Image PluginPic
        {
            get
            {
                if (_pluginPic == null)
                    _pluginPic = Image.FromFile(PluginPath + "\\Res\\呼叫管理.png");
                return _pluginPic;
            }
        }
        public Image SelectPluginPic
        {
            get
            {
                if (_selectPluginPic == null)
                    _selectPluginPic = Image.FromFile(PluginPath + "\\Res\\S呼叫管理.png");
                return _selectPluginPic;
            }
        }
        public string PluginId
        {
            get { return this.GetType().FullName; }
        }

        public string PluginPath
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
                return "呼叫管理";
            }
        }
    }
}
