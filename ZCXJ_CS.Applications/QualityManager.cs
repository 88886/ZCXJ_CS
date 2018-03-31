using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Repository;

namespace ZCXJ_CS.Applications
{
    public class QualityManager
    {
        public UnitOfWork UnitOfWorkQualityStandard = null;
        public DbContext context = new SQLiteContext();
        RepositoryBase<QualityStandard> rep = null;
        private string ProdNo;
        /// <summary>
        /// 构造函数
        /// </summary>
        public QualityManager()
        {
            UnitOfWorkQualityStandard = new UnitOfWork(context);
            rep = new RepositoryBase<QualityStandard>(UnitOfWorkQualityStandard);
        }
        /// <summary>
        /// 判断是否存在质检标准项，不存在则可异步下载
        /// </summary>
        /// <param name="prodNo">产品编号</param>
        /// <param name="asyncDownIfNone">是否从网络下载</param>
        public bool ExistQualityStandard(string prodNo,bool asyncDownIfNone)
        {
            ProdNo = prodNo;
            if (!rep.Exists(i => i.machineNo == GlobalData.MachineId && i.prodNo == ProdNo))
            {
                if (asyncDownIfNone)
                    AsyncDownLoadQualityStandard();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 异步下载制品质检标准项
        /// </summary>
        /// <param name="prodNo">产品编号</param>
        private void AsyncDownLoadQualityStandard()
        {
            GlobalData.Log.Info("开始异步下载质检标准数据！");
            HttpDataTrans httpPost = new HttpDataTrans();
            httpPost.OnDataTransCompleted += OnDataTransCompleted;
            httpPost.DataTransAsyn(GlobalData.CfgHelper.GetKeyValue("API_DownQualityStandard"), "",
                RequestType.POST, new { machineNo = GlobalData.MachineId, prodNo = ProdNo });
        }
        /// <summary>
        /// 传输完成事件处理
        /// </summary>
        /// <param name="result">数据</param>
        private void OnDataTransCompleted(string result,object param)
        {
            List<QualityStandard> newlst = JsonResult<List<QualityStandard>>.ConvertToModel(result);
            List<QualityStandard> lst = rep.GetList(i => i.machineNo == GlobalData.MachineId && i.prodNo == ProdNo).ToList();
            foreach (QualityStandard model in newlst)
            {
                QualityStandard localmodel = lst.FirstOrDefault(i => i.indicatorsNo == model.indicatorsNo);
                if (localmodel != null)
                {
                    localmodel.unit = model.unit;
                    localmodel.testType = model.testType;
                    localmodel.dataType = model.dataType;
                    localmodel.gatherWay = model.gatherWay;
                    localmodel.plcAddress = model.plcAddress;
                    localmodel.upTolerance = model.upTolerance;
                    localmodel.measureMethod = model.measureMethod;
                    localmodel.standardValue = model.standardValue;
                    localmodel.downTolerance = model.downTolerance;
                    localmodel.indicatorsName = model.indicatorsName;
                    rep.Update(localmodel);
                }
                else
                {
                    model.machineNo = GlobalData.MachineId;
                    model.prodNo = ProdNo;
                    rep.Add(model);
                }
            }
            UnitOfWorkQualityStandard.Commit();
            GlobalData.Log.Info("下载质检标准完成");
            //通知其它线程
        }
        
    }
}
