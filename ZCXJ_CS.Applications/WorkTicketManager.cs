using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Repository;
using System.Threading.Tasks;

namespace ZCXJ_CS.Applications
{
    public class WorkTicketManager
    {
        public event DataTransCompletedDelegate OnDownWTCompleted;
        public UnitOfWork UnitOfWorkWT = null;
        public DbContext context = new SQLiteContext();
        RepositoryBase<WorkTicket> rep = null;
        BomManager bomManager = null;

        //当前运行的工单对象
        public WorkTicket CurWorkTicket = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkTicketManager()
        {
            UnitOfWorkWT = new UnitOfWork(context);
            rep = new RepositoryBase<WorkTicket>(UnitOfWorkWT);
            CurWorkTicket = new WorkTicket();
            bomManager = new BomManager();
        }
        /// <summary>
        /// 获取指定编号的工单
        /// </summary>
        /// <param name="planNo"></param>
        /// <returns></returns>
        public WorkTicket GetByNo(string planNo)
        {
            return rep.Get(wt => (wt.planNo == planNo));
        }
        /// <summary>
        /// 获取未完成工单
        /// </summary>
        /// <param name="days">天数(例如7未一周内)</param>
        /// <param name="isFrozenIfRunOrPasue">是否更改运行或暂停的工单状态为中止</param>
        /// <returns></returns>
        public List<WorkTicket> GetUnfinishedList(int days, bool isFrozenIfRunOrPasue = false, bool IsNetConnected = true)
        {
            try
            {
                DateTime time = DateTime.Now.AddDays(days);
                List<WorkTicket> wtList = rep.GetList
                    (wt => ((wt.startTime > time) && (wt.UpdateState != 5)))
                    .ToList<WorkTicket>();
                if (wtList != null && wtList.Count > 0)
                {
                    for (int i = 0; i < wtList.Count; i++)
                    {
                        FillBomIfNull(wtList[i],IsNetConnected);
                        if (isFrozenIfRunOrPasue && (wtList[i].UpdateState == 1 || wtList[i].UpdateState == 2))
                        {
                            wtList[i].UpdateState = 3;
                        }
                        if (!wtList[i].isFillBom)
                        {
                            GlobalData.Log.Info("工单:[{0}]获取施工表失败!{1}后重新载入工单",
                                wtList[i].planNo,
                                IsNetConnected ? "请联系下单人员添加!" : "请连接到网络");
                        }
                    }
                }
                return wtList;
            }
            catch (Exception ex)
            {
                GlobalData.Log.Error(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 下载计划
        /// </summary>
        /// <param name="machineNo">机台编号</param>
        public void DownLoadWorkTicket()
        {
            HttpDataTrans httpPost = new HttpDataTrans();
            httpPost.OnDataTransCompleted += OnDataTransCompleted;
            httpPost.DataTransAsyn(GlobalData.CfgHelper.GetKeyValue("API_DownWorkTicket"), "",
                RequestType.POST, new { machineNo = GlobalData.MachineId });
        }
        /// <summary>
        /// 传输完成事件处理
        /// </summary>
        /// <param name="result"></param>
        void OnDataTransCompleted(string result,object param)
        {
            List<WorkTicket> lst = JsonResult<List<WorkTicket>>.ConvertToModel(result);
            foreach (WorkTicket model in lst)
            {
                WorkTicket localmodel = rep.Get(i => i.planNo == model.planNo);
                if (localmodel == null)
                {
                    rep.Add(model);
                }
                else if(localmodel.UpdateState == 0)
                {
                    localmodel.prodNo = model.prodNo;
                    localmodel.endTime = model.endTime;
                    localmodel.prodSpec = model.prodSpec;
                    localmodel.startTime = model.startTime;
                    localmodel.planAmount = model.planAmount;
                    localmodel.endTimeReal = model.endTimeReal;
                    localmodel.produceFlag = model.produceFlag;
                    localmodel.startTimeReal = model.startTimeReal;
                    localmodel.teamTimeInterval = model.teamTimeInterval;
                    localmodel.unit = model.unit;
                    rep.Update(localmodel);
                }
            }
            UnitOfWorkWT.Commit();
            //通知界面更新
            if (OnDownWTCompleted != null)
            {
                OnDownWTCompleted(result,param);
            }
        }
        /// <summary>
        /// 更新工单信息
        /// </summary>
        /// <param name="wt"></param>
        public void Update(WorkTicket wt)
        {
            rep.Update(wt);
            UnitOfWorkWT.Commit();
        }
        /// <summary>
        /// 删除工单
        /// </summary>
        /// <param name="wt"></param>
        public void Delete(WorkTicket wt)
        {
            rep.Delete(wt);
            UnitOfWorkWT.Commit();
        }
        /// <summary>
        /// 填充工单Bom如果Bom为空
        /// </summary>
        /// <param name="wt">工单</param>
        /// <returns>返回填充状态</returns>
        public void FillBomIfNull(WorkTicket wt, bool IsNetConnected = true)
        {
            bool isFillBom = wt.Bom != null && wt.Bom.mesTechMaterials != null && wt.Bom.mesTechMaterials.Count > 0;
            if (!isFillBom)
            {
                isFillBom = bomManager.GetPlanBomCache(wt.planNo, wt.prodNo, GlobalData.MachineId, wt.prodNo + "_GY01", ref wt.Bom, IsNetConnected);
            }
            wt.isFillBom = isFillBom;
        }
        /// <summary>
        /// 缓存工单Bom到数据库如果不为空
        /// </summary>
        /// <param name="wt">工单</param>
        /// <returns></returns>
        public bool SavePlanBomCacheIfNotNull(WorkTicket wt)
        {
            if (wt.isFillBom)
                return bomManager.SavePlanBomCache(wt.Bom, wt.planNo);
            return false;
        }
    }
}
