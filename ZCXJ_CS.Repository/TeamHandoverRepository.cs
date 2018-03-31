using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    public class TeamHandoverRepository : RepositoryBase<TeamHandover>
    {
        public TeamHandoverRepository(DbContext context)
            : base(context)
        {

        }

        public TeamHandoverRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
    }
}
