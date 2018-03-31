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
    public class BomTech : EntityBase
    {
        public BomTech() { }
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 工艺编号
        /// </summary>
        public string techNo { get; set; }
        /// <summary>
        /// 制品编号
        /// </summary>
        public string prodNo { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string machineNo { get; set; }
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
