using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.UI;

namespace ZCXJ_CS.Applications
{
    public class PrintQRCodeOpt : OperationBase
    {
        public PrintQRCodeOpt()
            : base("PrintQRCode")
        {
        }

        public override void Operate(object sender)
        {
            base.Operate(sender);
            FormTest frm = (FormTest)sender;
            frm.ShowPic(1);
        }
    }
}
