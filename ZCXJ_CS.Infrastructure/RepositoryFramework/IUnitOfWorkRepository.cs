using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCXJ_CS.Infrastructure
{
    public interface IUnitOfWorkRepository
    {
        void PersistAddItem(IEntity item);
        void PersistUpdateItem(IEntity item);
        void PersistDeleteItem(IEntity item);
    }
}
