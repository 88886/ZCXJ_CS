using Newtonsoft.Json;
using System.Collections.Generic;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 生产工装
    /// </summary>
    public class TechProduceToolss
    {
        public static Dictionary<string, string> GetCaptions()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("toolsNo", "工装编号");
            dic.Add("toolsName", "工装名称");
            dic.Add("toolsType", "工装分类");
            dic.Add("ToolsTypeName", "工装分类名");
            dic.Add("produceToolsCode", "上料条码(二维码/条型码)");
            return dic;
        }
        public TechProduceToolss() { }
        /// <summary>
        /// 工装编号
        /// </summary>
        public string toolsNo { get; set; }
        /// <summary>
        /// 工装名称
        /// </summary>
        public string toolsName { get; set; }
        /// <summary>
        /// 生产工装分类
        /// 1口型
        /// 2预口型
        /// 3流道
        /// 4压力锟
        /// 5整经锟
        /// </summary>
        public uint toolsType { get; set; }
        /// <summary>
        /// 生产工装分类
        /// </summary>
        public string ToolsTypeName
        {
            get
            {
                switch (toolsType)
                {
                    case 1:
                        return "口型";
                    case 2:
                        return "预口型";
                    case 3:
                        return "流道";
                    case 4:
                        return "压力锟";
                    case 5:
                        return "整经锟";
                    default:
                        return "未知";
                }
            }
        }
        /// <summary>
        /// 上料条码(二维码/条型码)
        /// </summary>
        public string produceToolsCode { get; set; }
    }
}
