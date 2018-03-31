using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using Newtonsoft.Json;

namespace ZCXJ_CS.Domain
{
    public  class TeamHandover : EntityBase
    {
        //所属公司
        public int groupId { get; set; }
        //部门（分厂）
        public int deptId { get; set; }
        //车间
        public int workshopId { get; set; }
        //机台
        public int machineId { get; set; }
        //机台编码
        public string machineNo { get; set; }
        //交接班ID
        public int shiftId { get; set; }
        //交班时间
        public DateTime handoverTime { get; set; }
        //交班班组长工号
        public string handTeamLeader { get; set; }
        //交班班组长名称
        public string handLeaderName { get; set; }
        //交班班组编号
        public string handTeamNo { get; set; }
        //交班人员列表
        public string handPersons { get; set; }
        //交班人员列表名称
        public string handPersonsName { get; set; }
        //交班班次
        public string handShift { get; set; }
        //接班班组长工号
        public string receiveTeamLeader { get; set; }
        //接班班组长名称
        public string receiveLeaderName { get; set; }
        //接班班组编号
        public string receiveTeamNo { get; set; }
        //接班班次
        public string receiveShift { get; set; }
        //接班时间
        public DateTime receiveTime { get; set; }
        //接班人员列表
        public string receivePersons { get; set; }
        //接班人员列表名称
        public string receivePersonsName { get; set; }
        //现场说明
        public string describe { get; set; }
        //JSON
        public string json { get; set; }
        //计划交班时间
        public DateTime planHandoverTime { get; set; }
        //计划接班时间
        public DateTime planReceiveTime { get; set; }

        public TeamHandover()
        {
            handoverTime = new DateTime(1900, 1, 1);
            receiveTime = new DateTime(1900, 1, 1);
            planHandoverTime = new DateTime(1900, 1, 1);
            planReceiveTime = new DateTime(1900, 1, 1);
        }
    }
}
