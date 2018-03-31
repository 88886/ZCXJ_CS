/**************************************************************************************
 * 文 件 名：TurnOverCardManager 
 * 内    容：
 * 功    能：
 * 作    者：wuyunhai
 * 日    期：2016/9/7 14:23:46
 * 修改日志: 
 * 版权说明: 
 * *************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Repository;

namespace ZCXJ_CS.Applications
{
    public class TurnOverCardManager
    {
        public event DataTransCompletedDelegate OnUpTurnOverCard;
        //周转卡列表
        public List<TurnOverCard> CardList;

        #region 变量

        private DbContext db;
        private UnitOfWork uw;
        private RepositoryBase<TurnOverCard> rep;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public TurnOverCardManager()
        {
            db = new SQLiteContext();
            uw = new UnitOfWork(db);
            rep = new RepositoryBase<TurnOverCard>(uw);
            CardList = new List<TurnOverCard>();
        }

        #endregion

        //从当前工单信息中生成周转卡
        public TurnOverCard GenCard(WorkTicket wt)
        {
            try
            {
                TurnOverCard card = new TurnOverCard();
                card.qrCode = card.turnoverNo;
                card.planNo = wt.planNo;
                card.shiftNo = "";
                card.shiftName = "";
                card.teamNo = "";
                card.teamName = "";
                card.carryNo = "";
                card.prodType = GlobalData.Process;
                card.prodNo = wt.prodNo;
                card.prodStandard = wt.prodSpec;
                card.machineNo = GlobalData.MachineId;
                card.producePersons = GlobalData.CurUser.userName;
                card.produceTime = DateTime.Now;
                card.stToolsNo = "";
                card.stAmount = (int)wt.completeAmount;
                if (wt.Bom != null)
                {
                    if (wt.Bom.mesTechProduceToolss.Count > 0)
                        card.produceTool1 = wt.Bom.mesTechProduceToolss[0].produceToolsCode;
                    if (wt.Bom.mesTechProduceToolss.Count > 1)
                        card.produceTool2 = wt.Bom.mesTechProduceToolss[1].produceToolsCode;
                    if (wt.Bom.mesTechProduceToolss.Count > 2)
                        card.produceTool3 = wt.Bom.mesTechProduceToolss[2].produceToolsCode;
                    if (wt.Bom.mesTechProduceToolss.Count > 3)
                        card.produceTool4 = wt.Bom.mesTechProduceToolss[3].produceToolsCode;
                    if (wt.Bom.mesTechMaterials.Count > 0)
                        card.materialNo1 = wt.Bom.mesTechMaterials[0].materialNo;
                    if (wt.Bom.mesTechMaterials.Count > 1)
                        card.materialNo2 = wt.Bom.mesTechMaterials[1].materialNo;
                    if (wt.Bom.mesTechMaterials.Count > 2)
                        card.materialNo3 = wt.Bom.mesTechMaterials[2].materialNo;
                    if (wt.Bom.mesTechMaterials.Count > 3)
                        card.materialNo4 = wt.Bom.mesTechMaterials[3].materialNo;
                }
                card.applyProdSpecList = "";
                card.shelfLifeTime = card.produceTime.AddHours(4);
                card.expiredTime = card.produceTime.AddHours(72);
                card.startUseTime = card.produceTime.AddHours(4);
                card.endUseTime = card.produceTime.AddHours(72);
                card.prodSelfCheck = "合格";
                card.isFirstProd = "0";
                card.checkInfo = "";
                card.technologyNotion = "";
                card.adviseStoreArea = "";
                card.adviseUseMachine = "";
                card.produceAddress = "";
                card.useAddress = "";
                card.json = "";
                card.creator = GlobalData.CurUser.userId;
                return card;
            }
            catch (Exception ex)
            {
                GlobalData.Log.Error("周转卡生成失败：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 上传周转卡
        /// </summary>
        public void UploadTurnOverCard(TurnOverCard card)
        {
            var requestData = new
            {
                turnoverNo = card.turnoverNo,
                qrCode = card.qrCode,
                planNo = card.planNo,
                shiftNo = card.shiftNo,
                shiftName = card.shiftName,
                teamNo = card.teamNo,
                teamName = card.teamName,
                carryNo = card.carryNo,
                prodType = card.prodType,
                prodNo = card.prodNo,
                prodStandard = card.prodStandard,
                machineNo = card.machineNo,
                producePersons = card.producePersons,
                produceTime = card.produceTime,
                stToolsNo = card.stToolsNo,
                stAmount = card.stAmount,
                produceTool1 = card.produceTool1,
                produceTool2 = card.produceTool2,
                produceTool3 = card.produceTool3,
                produceTool4 = card.produceTool4,
                produceToolsList = string.Format("{0},{1},{2},{3}", card.produceTool1,
                card.produceTool2, card.produceTool3, card.produceTool4),
                materialNo1 = card.materialNo1,
                materialNo2 = card.materialNo2,
                materialNo3 = card.materialNo3,
                materialNo4 = card.materialNo4,
                materialNoList = string.Format("{0},{1},{2},{3}", card.materialNo1,
                card.materialNo2, card.materialNo3, card.materialNo4),
                applyProdSpecList = card.applyProdSpecList,
                shelfLifeTime = card.shelfLifeTime,
                expiredTime = card.expiredTime,
                startUseTime = card.startUseTime,
                endUseTime = card.endUseTime,
                prodSelfCheck = card.prodSelfCheck,
                isFirstProd = card.isFirstProd,
                checkInfo = card.checkInfo,
                technologyNotion = card.technologyNotion,
                adviseStoreArea = card.adviseStoreArea,
                adviseUseMachine = card.adviseUseMachine,
                produceAddress = card.produceAddress,
                useAddress = card.useAddress,
                json = card.json,
                creator = card.creator
            };
            HttpDataTrans httpPost = new HttpDataTrans();
            httpPost.OnDataTransCompleted += new DataTransCompletedDelegate(OnDataTransCompleted);
            httpPost.DataTransAsyn(GlobalData.CfgHelper.GetKeyValue("API_UpTurnOverCard"), "",
                RequestType.POST, requestData);
        }

        /// <summary>
        /// 获取相同工单计划中的周转卡
        /// </summary>
        /// <param name="planNo"></param>
        public void LoadCardList(string planNo)
        {
            CardList = new List<TurnOverCard>();
            try
            {
                CardList = this.GetList(t => (t.planNo == planNo));
            }
            catch (Exception ex)
            {
                ;
            }
        }


        /// <summary>
        /// 传输完成事件处理
        /// </summary>
        /// <param name="result"></param>
        void OnDataTransCompleted(string result,object param)
        {
            //通知界面更新
            if (OnUpTurnOverCard != null)
            {
                OnUpTurnOverCard(result,null);
            }
        }

        #region 增加

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="tcard"></param>
        public void Add(TurnOverCard tcard)
        {
            rep.Add(tcard);
            uw.Commit();
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tcard"></param>
        public void Update(TurnOverCard tcard)
        {
            rep.Update(tcard);
            uw.Commit();
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tcard"></param>
        public void Delete(TurnOverCard tcard)
        {
            rep.Delete(tcard);
            uw.Commit();
        }
        #endregion

        #region 获得一条记录

        /// <summary>
        /// 获得一条记录
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public TurnOverCard Get(Expression<Func<TurnOverCard, bool>> exp)
        {
            return rep.Get(exp);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="qt"></param>
        public List<TurnOverCard> GetList(Expression<Func<TurnOverCard, bool>> exp)
        {
            if (exp != null)
            {
                List<TurnOverCard> tcardList = new List<TurnOverCard>();
                tcardList = rep.GetList(exp).ToList<TurnOverCard>();
                return tcardList;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 是否存在该记录

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Expression<Func<TurnOverCard, bool>> exp)
        {
            return rep.Exists(exp);
        }
        #endregion

        #region 获取记录数

        /// <summary>
        /// 获取记录数
        /// </summary>
        public int GetCounts(Expression<Func<TurnOverCard, bool>> exp = null)
        {
            return rep.GetCounts(exp);
        }

        #endregion
    }
}
