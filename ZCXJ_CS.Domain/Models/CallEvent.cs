using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using Newtonsoft.Json;

namespace ZCXJ_CS.Domain
{
    public class CallEvent : EntityBase
    {
        public CallEvent()
        { }

        //所属公司
        public int groupId { get; set; }
        //部门（分厂）
        public int deptId { get; set; }
        //车间
        public int workshopId { get; set; }
        //机台
        public int machineId { get; set; }
        //呼叫ID
        public int callId { get; set; }
        //计划编号
        public string planNo { get; set; }
        //事件编号
        public string eventNo { get; set; }
        //呼叫类型
        public int callType { get; set; }
        //呼叫时间
        public DateTime callTime { get; set; }
        //呼叫申请人工号
        public string callApplyPerson { get; set; }
        //呼叫申请人名称
        public string callApplyName { get; set; }
        //呼叫处理人工号
        public string callProcessPerson { get; set; }
        //呼叫处理人名称
        public string callProcessName { get; set; }
        //开始处理时间
        public DateTime startProcessTime { get; set; }
        //确认人工号
        public string callEnsurePerson { get; set; }
        //确认人名称
        public string callEnsureName { get; set; }
        //处理完成时间
        public DateTime endProcessTime { get; set; }
        //结果描述
        public string describe { get; set; }
        //JSON
        public string json { get; set; }
        //事件状态

        public int eventState { get; set; }
        //public int eventState
        //{
        //    set
        //    {
        //        eventState = value;
        //        if (eventState == 0)
        //        {
        //            eventstateName = "待料呼叫";
        //        }
        //        else if (eventState == 1)
        //        {
        //            eventstateName = "维保呼叫";
        //        }
        //        else if (eventState == 2)
        //        {
        //            eventstateName = "质检呼叫";
        //        }

        //    }
        //    get { return eventState; }
        //}
        //事件内容
        public string eventContent { get; set; }

        //事件状态名称
        public string eventstateName { get; set; }

        //呼叫次数
        public int callCount { get; set; }
  

    }
}
