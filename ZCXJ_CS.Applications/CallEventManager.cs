using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Repository;

namespace ZCXJ_CS.Applications
{
    public class CallEventManager
    {
        public UnitOfWork UnitOfWorkWT = null;
        public DbContext context = new SQLiteContext();
        RepositoryBase<CallEvent> rep = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CallEventManager()
        {
            UnitOfWorkWT = new UnitOfWork(context);
            rep = new RepositoryBase<CallEvent>(UnitOfWorkWT);
        }

        /// <summary>
        /// 查询呼叫记录
        /// </summary>
        /// <param name="calltype">呼叫类型</param>
        /// <returns></returns>
        public List<CallEvent> GetList(string calltype)
        {
            List<CallEvent> ceList = new List<CallEvent>();
            if (calltype == "全部")
            {
                ceList = rep.GetList
               ().OrderByDescending(wt => wt.callTime)
               .ToList<CallEvent>();
            }
            else
            {
                ceList = rep.GetList
               (wt => (wt.eventstateName == calltype)).OrderByDescending(wt => wt.callTime)
               .ToList<CallEvent>();
            }
           
            return ceList;
        }

        /// <summary>
        /// 上传呼叫事件
        /// </summary>
        /// <param name="model"></param>
        public void UpEnvent(CallEvent model)
        {
            HttpDataTrans http = new HttpDataTrans();
            string url = GlobalData.CfgHelper.GetKeyValue("API_UpEventCall");
            string No = GlobalData.MachineId;
            var requestData = new
            {
                machineNo = No,
                planNo = model.planNo,
                eventNo = model.eventNo,
                callType = model.callType,
                callTime = model.callTime,
                callApplyPerson = model.callApplyPerson,
                callProcessPerson = model.callProcessPerson,
                startProcessTime = model.startProcessTime,
                endProcessTime = model.endProcessTime,
                describe = model.Remark
            };
            http.OnDataTransCompleted += Http_OnDataTransCompleted;
            http.DataTransAsyn(url, "", RequestType.POST, requestData);
        }
        /// <summary>
        /// 同步完成事件
        /// </summary>
        /// <param name="data"></param>
        private void Http_OnDataTransCompleted(string data,object param)
        {
            if (string.IsNullOrEmpty(data) || !JsonResult<object>.IsOK(data))
            {
                GlobalData.Log.Info("上次呼叫数据失败!");
            }
        }

        /// <summary>
        /// 生成新的ID
        /// </summary>
        /// <param name="CEList"></param>
        /// <returns></returns>
        public string CallID(List<CallEvent> CEList)
        {
            string ID = "";
            CallEvent max = CEList.OrderByDescending(i => i.eventNo).FirstOrDefault();
            if (max != null && DateTime.Now.Day == max.callTime.Day)
            {
                ID = max.eventNo.Substring(0, 10) + (int.Parse(max.eventNo.Substring(10)) + 1).ToString("000");
            }
            else
            {
                ID = "CE" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            return ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="wt"></param>
        public void Update(CallEvent wt)
        {
            rep.Update(wt);
            UnitOfWorkWT.Commit();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wt"></param>
        public void Delete(CallEvent wt)
        {
            rep.Delete(wt);
            UnitOfWorkWT.Commit();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="wt"></param>
        public void Add(CallEvent wt)
        {
            rep.Add(wt);
            UnitOfWorkWT.Commit();
        }

    }
}
