using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 标准文件
    /// </summary>
    public class TechStandardFiles
    {
        public TechStandardFiles() { }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string fileCode { get;set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string filePath { get; set; }
        /// <summary>
        /// 文件分类
        /// 1作业指导书 
        /// 2质量控制计划
        /// </summary>
        public uint fileClass { get; set; }
    }
}
