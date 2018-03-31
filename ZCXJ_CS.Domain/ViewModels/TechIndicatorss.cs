using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 工艺指标
    /// </summary>
    public class TechIndicatorss
    {
        public static Dictionary<string,string> GetCaptions()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("indicatorsNo", "指标项编号");
            dic.Add("indicatorsName", "指标项名称");
            dic.Add("indicatorsClass", "指标项分类");
            dic.Add("standardValue", "标准值");
            dic.Add("upTolerance", "上公差");
            dic.Add("downTolerance", "下公差");
            dic.Add("unit", "单位");
            dic.Add("dataType", "数据类型");
            return dic;
        }
        public TechIndicatorss() { }
        /// <summary>
        /// 指标项编号
        /// </summary>
        public string indicatorsNo { get; set; }
        /// <summary>
        /// 指标项名称
        /// </summary>
        public string indicatorsName { get; set; }
        /// <summary>
        /// 指标项分类
        /// </summary>
        public uint indicatorsClass { get; set; }
        /// <summary>
        /// 标准值
        /// </summary>
        public string standardValue { get; set; }
        /// <summary>
        /// 上公差
        /// </summary>
        public string upTolerance { get; set; }
        /// <summary>
        /// 下公差
        /// </summary>
        public string downTolerance { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string dataType { get; set; }
    }
}
