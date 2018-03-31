/**************************************************************************************
 * 文 件 名：TurnOverCardRepository 
 * 内    容：周转卡仓储类
 * 功    能：
 * 作    者：wuyunhai
 * 日    期：2016/9/7 14:12:11
 * 修改日志: 
 * 版权说明: 
 * *************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.Repository
{
    public class TurnOverCardRepository : RepositoryBase<TurnOverCard>
    {
        public TurnOverCardRepository(DbContext context)
            : base(context)
        { 
        
        }

        public TurnOverCardRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

    }
}
