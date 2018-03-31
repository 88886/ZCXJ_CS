using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 施工表Bom
    /// </summary>
    public class BomCache : EntityBase
    {
        public BomCache() { }
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 计划编号
        /// </summary>
        public string planNo { get; set; }
        /// <summary>
        /// 数据类型名称
        /// </summary>
        public string dataType { get; set; }
        /// <summary>
        /// 数据Json
        /// </summary>
        public string dataJson { get; set; }

    }
}
