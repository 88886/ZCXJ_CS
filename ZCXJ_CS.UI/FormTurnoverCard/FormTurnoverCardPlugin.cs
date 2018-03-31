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

    //MEF 组件以声明方式同时指定其依赖项（称为“导入”）及其提供的功能（称为“导出”）
    [Export(typeof(IUIPlugin))]
    public class FormTurnoverCardPlugin : IUIPlugin
    {
        private FormBase _pluginForm = null;
        private Image _pluginPic = null;
        private Image _selectPluginPic = null;
        public FormBase PluginForm
        {
            get
            {
                if (_pluginForm == null)
                    _pluginForm = new FormTurnoverCard();
                return _pluginForm;
            }
        }

        public Image PluginPic
        {
            get
            {
                if (_pluginPic == null)
                    _pluginPic = Image.FromFile(PluginPath + "\\Res\\周转卡管理.png");
                return _pluginPic;
            }
        }
        public Image SelectPluginPic
        {
            get
            {
                if (_selectPluginPic == null)
                    _selectPluginPic = Image.FromFile(PluginPath + "\\Res\\S周转卡管理.png");
                return _selectPluginPic;
            }
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
                return "周转卡管理";
            }
        }
    }
}
