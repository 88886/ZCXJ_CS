using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ZCXJ_CS.UI
{
    [Export(typeof(IUIPlugin))]
    public class FormMateriaCheckPlugin : IUIPlugin
    {
        private FormBase _pluginForm = null;
        private Image _pluginPic = null;
        private Image _selectPluginPic = null;
        public FormBase PluginForm 
        {
            get
            {
                if (_pluginForm == null)
                    _pluginForm = new FormMateriaCheck();
                return _pluginForm;
            }
        }

        public Image PluginPic
        {
            get
            {
                if (_pluginPic == null)
                    _pluginPic = Image.FromFile(PluginPath + "\\Res\\上料防错.png");
                return _pluginPic;
            }
        }
        public Image SelectPluginPic
        {
            get
            {
                if (_selectPluginPic == null)
                    _selectPluginPic = Image.FromFile(PluginPath + "\\Res\\S上料防错.png");
                return _selectPluginPic;
            }
        }

        public virtual string PluginId
        {
            get
            {
                return this.GetType().FullName;
            }
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
                return "上料防错";
            }
        }
    }
}
