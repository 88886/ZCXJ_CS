using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
         public UserRepository(DbContext context)
            : base(context)
        {

        }

         public UserRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
    }
}
