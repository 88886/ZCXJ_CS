﻿using System.ComponentModel.Composition;
using System.Drawing;
using System.Reflection;
 
namespace ZCXJ_CS.UI
{
    [Export(typeof(IUIPlugin))]
    public class FormProcessViewPlugin : IUIPlugin
    {
        private FormBase _pluginForm = null;
        private Image _pluginPic = null;
        private Image _selectPluginPic = null;
        public FormBase PluginForm
        {
            get
            {
                if (_pluginForm == null)
                    _pluginForm = new FormProcessView();
                return _pluginForm;
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

        public System.Drawing.Image PluginPic
        {
            get
            {
                if (_pluginPic == null)
                    _pluginPic = Image.FromFile(PluginPath + "\\Res\\制成工序.png");
                return _pluginPic;
            }
        }

        public string PluginText
        {
            get
            {
                return "制程工序";
            }
        }

        public System.Drawing.Image SelectPluginPic
        {
            get
            {
                if (_selectPluginPic == null)
                    _selectPluginPic = Image.FromFile(PluginPath + "\\Res\\制成工序.png");
                return _selectPluginPic;
            }
        }
    }
}
