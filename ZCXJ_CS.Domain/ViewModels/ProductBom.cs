using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 制品Bom
    /// </summary>
    public class ProductBom
    {
        /// <summary>
        /// 工艺指标Json
        /// </summary>
        public string Indicatorss { get; set; }
        /// <summary>
        /// 质量控制Json
        /// </summary>
        public string QualityControls { get; set; }
        /// <summary>
        /// 工艺本地参数Json
        /// </summary>
        public string LocalParams { get; set; }
        /// <summary>
        /// 物料和装配Json
        /// </summary>
        public string Materials { get; set; }
        /// <summary>
        /// 生产工装Json
        /// </summary>
        public string ProduceToolss { get; set; }
        /// <summary>
        /// 标准文件Json
        /// </summary>
        public string StandardFiles { get; set; }
        /// <summary>
        /// 工艺指标列表
        /// </summary>
        public List<TechIndicatorss> mesTechIndicatorss
        {
            get { return JsonHelper.Deserialize<List<TechIndicatorss>>(Indicatorss); }
            set { Indicatorss = JsonHelper.Serialize(value); }
        }
        /// <summary>
        /// 质量控制列表
        /// </summary>
        public List<TechQualityControls> mesTechQualityControls
        {
            get { return JsonHelper.Deserialize<List<TechQualityControls>>(QualityControls); }
            set { QualityControls = JsonHelper.Serialize(value); }
        }
        /// <summary>
        /// 工艺本地参数列表
        /// </summary>
        public List<TechLocalParams> mesTechLocalParams
        {
            get { return JsonHelper.Deserialize<List<TechLocalParams>>(LocalParams); }
            set { LocalParams = JsonHelper.Serialize(value); }
        }
        /// <summary>
        /// 物料列表
        /// </summary>
        public List<TechMaterials> mesTechMaterials
        {
            get { return JsonHelper.Deserialize<List<TechMaterials>>(Materials); }
            set { Materials = JsonHelper.Serialize(value); }
        }
        /// <summary>
        /// 生产工装列表
        /// </summary>
        public List<TechProduceToolss> mesTechProduceToolss
        {
            get { return JsonHelper.Deserialize<List<TechProduceToolss>>(ProduceToolss); }
            set { ProduceToolss = JsonHelper.Serialize(value); }
        }
        /// <summary>
        /// 标准文件列表
        /// </summary>
        public List<TechStandardFiles> mesTechStandardFiles
        {
            get { return JsonHelper.Deserialize<List<TechStandardFiles>>(StandardFiles); }
            set { StandardFiles = JsonHelper.Serialize(value); }
        }
    }
}
