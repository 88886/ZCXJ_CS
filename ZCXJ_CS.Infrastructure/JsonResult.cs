using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Infrastructure
{
    public partial class JsonResult<T> where T : class, new()
    {

        public JsonResult() 
        { }
        //通讯返回代码
        public string code { get; set; }
        //接口数据
        public T data { get; set; }
        //通讯消息
        public string message { get; set; }
        //是否成功标记
        public bool success { get; set; }
        //
        public string totalCount { get; set; }
        public string lastTime { get; set; }
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    public partial class JsonResult<T> where T : class, new()
    {
        //日志对象
        private static LogHelper log = LogHelper.GetInstence();

        /// <summary>
        /// 从Json字符串转换为对象
        /// </summary>
        /// <param name="JsonData"></param>
        /// <returns></returns>
        public static T ConvertToModel(string JsonData)
        {
            try
            {
                if (string.IsNullOrEmpty(JsonData))
                    throw new Exception("下载数据为空！");
                var result = JsonHelper.Deserialize<JsonResult<T>>(JsonData);
                return result.success ? result.data : new T();
            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
                return new T();
            }
        }

        public static bool IsOK(string JsonData)
        {
            try
            {
                var result = JsonHelper.Deserialize<JsonResult<Object>>(JsonData);
                return result.success;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
