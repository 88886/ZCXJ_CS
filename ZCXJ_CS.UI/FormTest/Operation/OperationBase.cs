using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCXJ_CS.Applications
{
    public class OperationBase : IOperation
    {
        public string OperationId
        {
            get;
            set;
        }

        public OperationBase(string id)
        {
            OperationId = id;
        }

        public virtual void Operate(object sender)
        {
            ;
        }
    }
}
