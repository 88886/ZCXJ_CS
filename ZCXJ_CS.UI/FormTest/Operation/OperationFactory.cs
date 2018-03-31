using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCXJ_CS.Applications
{
    public class OperationFactory
    {
        public void LoadOperations()
        {

        }

        public static IOperation BulidOperation(string id)
        {
            switch (id)
            {
            case "PrintTurnCard":
                return new PrintTurnCardOpt();
            case "PrintQRCode":
                return new PrintQRCodeOpt();
            default:
                return null;
            }
        }
    }
}
