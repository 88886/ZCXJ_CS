using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 工艺本地参数
    /// </summary>
    public class TechLocalParams
    {
        public TechLocalParams() { }
        /// <summary>
        /// 参数名字
        /// </summary>
        public string paramName { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public uint paramType { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public string paramVal { get; set; }
    }
}
