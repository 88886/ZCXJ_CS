﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 质检结果项
    /// </summary>
    public class QualityRecordItem : EntityBase
    {
        /// <summary>
        /// 质检记录编号
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string qcNo { get; set; }
        /// <summary>
        /// 指标项编号
        /// </summary>
        public string indicatorsNo { get; set; }
        /// <summary>
        /// 指标项名称
        /// </summary>
        public string indicatorsName { get; set; }
        /// <summary>
        /// 测量方法
        /// </summary>
        public string measureMethod { get; set; }
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
        public int dataType { get; set; }
        /// <summary>
        /// PLC地址
        /// </summary>
        public string plcAddress { get; set; }
        /// <summary>
        /// 实际值
        /// </summary>
        public string factValue { get; set; }
    }
}
