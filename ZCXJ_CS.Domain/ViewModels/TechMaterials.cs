using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Domain
{
    /// <summary>
    /// 物料
    /// </summary>
    public class TechMaterials
    {
        public static Dictionary<string, string> GetCaptions()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("materialNo", "物料编码");
            dic.Add("materialName", "物料名称");
            dic.Add("materialCode", "上料条码(二维码/条型码)");
            return dic;
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string materialNo { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string materialName { get; set; }
        /// <summary>
        /// 上料条码(二维码/条型码)
        /// </summary>
        public string materialCode { get; set; }
        /// <summary>
        /// 装配列表
        /// </summary>
        public List<TechMaterialAssemblys> mesTechMaterialAssemblys { get; set; }
    }
}
