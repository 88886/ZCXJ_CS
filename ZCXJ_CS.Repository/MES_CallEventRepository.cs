using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    public class MES_CallEventRepository : RepositoryBase<CallEvent>
    {
         public MES_CallEventRepository(DbContext context)
            : base(context)
        {

        }

         public MES_CallEventRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
    }
}
