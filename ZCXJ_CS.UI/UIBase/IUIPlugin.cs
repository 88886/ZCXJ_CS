using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace ZCXJ_CS.UI
{
    public interface IUIPlugin
    {
        /// <summary>
        /// 插件ID
        /// </summary>
        string PluginId
        {
            get;
        }

        /// <summary>
        /// 设置加载的窗体
        /// </summary>
        FormBase PluginForm
        {
            get;
        }
        /// <summary>
        /// 插件模块名称
        /// </summary>
        string PluginText
        {
            get;
        }
        /// <summary>
        /// 插件显示图片
        /// </summary>
        Image PluginPic
        {
            get;
        }
        /// <summary>
        /// 插件显示图片
        /// </summary>
        Image SelectPluginPic
        {
            get;
        }
        /// <summary>
        /// Dll文件路径
        /// </summary>
        string PluginPath
        {
            get;
        }
    }
}
