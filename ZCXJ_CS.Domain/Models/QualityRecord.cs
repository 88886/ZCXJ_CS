using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 质检记录
    /// </summary>
    public class QualityRecord : EntityBase
    {
        /// <summary>
        /// 机台编号
        /// </summary>
        public string machineNo { get; set; }
        /// <summary>
        /// 质检记录编号
        /// </summary>
        public string qcNo { get; set; }
        /// <summary>
        /// 质检计划编号
        /// </summary>
        public string qcPlanNo { get; set; }
        /// <summary>
        /// 周转卡编号
        /// </summary>
        public string turnoverNo { get; set; }
        /// <summary>
        /// 制品编号
        /// </summary>
        public string prodNo { get; set; }
        /// <summary>
        /// 制品类别
        /// </summary>
        public string prodType { get; set; }
        /// <summary>
        /// 生产计划编号
        /// </summary>
        public string planNo { get; set; }
        /// <summary>
        /// 质检类型
        /// </summary>
        public string qcType { get; set; }
        /// <summary>
        /// 质检结果
        /// </summary>
        public string qcResult { get; set; }
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime checkTime { get; set; }
        /// <summary>
        /// 检查人
        /// </summary>
        public string checkPerson { get; set; }
        /// <summary>
        /// 质检明细项列表
        /// </summary>
        public List<QualityRecordItem> QcRecordItems { get; set; }
    }
}
