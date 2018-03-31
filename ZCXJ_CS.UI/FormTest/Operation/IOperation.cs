using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCXJ_CS.Applications
{
    public interface IOperation
    {
        string OperationId
        {
            get;
        }

        void Operate(object send);
    }
}
