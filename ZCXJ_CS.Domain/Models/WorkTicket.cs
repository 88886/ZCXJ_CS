using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Domain
{
    public enum WTState
    {
        None = 0,       //初始状态
        Running,        //1，运行中
        Pause,          //2，暂停
        Frozen,         //3，冻结（中止）
        Finished,       //4，完工
        PreRunL,        //5，预切换1级
        PreRunH,        //6，预切换2级
        End = 100,      //100，终止
        Cancel = 101,   //101，取消
    }

    public class WorkTicket : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 工单编号
        /// </summary>
        public string planNo { get; set; }
        /// <summary>
        /// 制品编号
        /// </summary>
        public string prodNo { get; set; }
        /// <summary>
        /// 制品规格
        /// </summary>
        public string prodSpec { get; set; }
        /// <summary>
        /// 生产标记
        /// </summary>
        public uint produceFlag { get; set; }
        /// <summary>
        /// 时段
        /// </summary>
        public uint teamTimeInterval { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime endTime { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime startTimeReal { get; set; }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime endTimeReal { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        public double planAmount { get; set; }
        /// <summary>
        /// 完成数量
        /// </summary>
        public double completeAmount { get; set; }
        /// <summary>
        /// 数量单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 是否填充Bom
        /// </summary>
        public bool isFillBom;
        /// <summary>
        /// 工单对应的BOM
        /// </summary>
        public ProductBom Bom;
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkTicket()
        {
            startTime = new DateTime(1900,1,1);
            startTime = new DateTime(1900, 1, 1);
            startTimeReal = new DateTime(1900, 1, 1);
            endTimeReal = new DateTime(1900, 1, 1);
            planNo = string.Empty;
            produceFlag = 0;
            teamTimeInterval = 0;
            planAmount = 0.0;
            completeAmount = 0.0;
        }
        /// <summary>
        /// 获取工单状态
        /// </summary>
        /// <returns></returns>
        public WTState GetWTState()
        {
            return (WTState)UpdateState;
        }
    }
}
