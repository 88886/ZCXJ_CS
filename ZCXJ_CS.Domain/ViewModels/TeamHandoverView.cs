using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using Newtonsoft.Json;

namespace ZCXJ_CS.Domain
{
    public class TeamHandoverView
    {
        public TeamHandoverView() { }
        public static Dictionary<string, string> GetCaptions()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("receiveTime", "接班时间");
            dic.Add("receiveLeaderName", "接班主手");
            dic.Add("receivePersonsName", "接班班组人员");
            dic.Add("handoverTime", "交班时间");
            dic.Add("handLeaderName", "交班主手");
            dic.Add("handPersonsName", "交班班组人员");
            dic.Add("describe", "交班备注");
            dic.Add("remark", "接班备注");
            return dic;
        }
        //交班时间
        public string handoverTime { get; set; }
        //交班班组长名称
        public string handLeaderName { get; set; }
        //交班人员列表名称
        public string handPersonsName { get; set; }
        //接班班组长名称
        public string receiveLeaderName { get; set; }
        //接班时间
        public string receiveTime { get; set; }
        //接班人员列表名称
        public string receivePersonsName { get; set; }
        //现场说明
        public string describe { get; set; }
        //备注
        public string remark { get; set; }

    }
}
