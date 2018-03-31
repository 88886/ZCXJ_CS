/**************************************************************************************
 * 文 件 名：TurnOverCardMap 
 * 内    容：周转卡映射文件
 * 功    能：
 * 作    者：wuyunhai
 * 日    期：2016/9/7 14:13:34
 * 修改日志: 
 * 版权说明: 
 * *************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    public class TurnOverCardMap: EntityTypeConfiguration<TurnOverCard>
    {
        public TurnOverCardMap()
        {
            HasKey(x => x.turnoverNo);
            Property(x => x.turnoverNo).IsRequired();
        }
    }
}