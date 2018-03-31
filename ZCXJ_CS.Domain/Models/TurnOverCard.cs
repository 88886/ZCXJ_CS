/**************************************************************************************
 * 文 件 名：TurnOverCard 
 * 内    容：周转卡实体类
 * 功    能：
 * 作    者：wuyunhai
 * 日    期：2016/9/7 13:02:08
 * 修改日志: 
 * 2016/9/21 yuwujia
 * 版权说明: 
 * *************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    public class TurnOverCard : EntityBase
    {
        public TurnOverCard()
        {
            groupId = 0;
            deptId = workShopId = "";
            turnoverNo = "TC" + DateTime.Now.ToString("yyyyMMddHHmmss");
            materialNo1 = materialNo2 = materialNo3 = materialNo4 = "";
            produceTool1 = produceTool2 = produceTool3 = produceTool4 = "";
        }
        //公司ID
        public int groupId { get; set; }

        //部门ID
        public string deptId { get; set; }

        //车间ID 
        public string workShopId { get; set; }

        //周转卡编号 
        public string turnoverNo { get; set; }

        //二维码 
        public string qrCode { get; set; }

        //计划编号 
        public string planNo { get; set; }

        //班次编号 
        public string shiftNo { get; set; }

        //班次名称
        public string shiftName { get; set; }

        //班组编号 
        public string teamNo { get; set; }

        //班组名称
        public string teamName { get; set; }

        //物流编号 
        public string carryNo { get; set; } 

        //制品类别  
        public string prodType { get; set; }

        //制品编号 
        public string prodNo { get; set; }

        //制品规格 
        public string prodStandard { get; set; }

        //机台编号 
        public string machineNo { get; set; } 

        //生产人员 
        public string producePersons { get; set; }

        //生产时间 
        public DateTime produceTime { get; set; }

        //贮运工装 
        public string stToolsNo { get; set; }

        //载料数量 
        public int stAmount { get; set; }

        //生产工装1 
        public string produceTool1 { get; set; }

        //生产工装2 
        public string produceTool2 { get; set; }

        //生产工装3 
        public string produceTool3 { get; set; }

        //生产工装4 
        public string produceTool4 { get; set; }

        //物料1
        public string materialNo1 { get; set; }

        //物料2
        public string materialNo2 { get; set; }

        //物料3
        public string materialNo3 { get; set; }

        //物料4
        public string materialNo4 { get; set; }

        /// <summary>
        /// 适用在制品规格
        /// </summary>
        public string applyProdSpecList { get; set; }

        //保质时间 
        public DateTime shelfLifeTime { get; set; }

        //过期时间 
        public DateTime expiredTime { get; set; }

        //开始使用时间 
        public DateTime startUseTime { get; set; }

        //结束使用时间 
        public DateTime endUseTime { get; set; }

        //制品自检 
        public string prodSelfCheck { get; set; }

        //是否首件 
        public string isFirstProd { get; set; }

        //质检信息 
        public string checkInfo { get; set; }

        //技术意见 
        public string technologyNotion { get; set; }

        //建议存放库位 
        public string adviseStoreArea { get; set; }

        //建议使用机台 
        public string adviseUseMachine { get; set; }

        //产地 
        public string produceAddress { get; set; }

        //使用地 
        public string useAddress { get; set; }

        //JSON 
        public string json { get; set; } 

        //创建人 
        public string creator { get; set; }

    }
}
