using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillPrintEngine;

namespace ZCXJ_CS.UI
{
    public partial class DlgPreview : Form
    {
        public BillsPrint billsPrint;

        public DlgPreview()
        {
            InitializeComponent();
        }

        private void DlgPreview_Load(object sender, EventArgs e)
        {
            if (billsPrint.Pages_T > 0)
            {
                previewCtrl.Document = billsPrint.PrintDocT;
            }
            else if (billsPrint.Pages_S > 0)
            {
                previewCtrl.Document = billsPrint.PrintDocS;
            }
            else if (billsPrint.Pages_D > 0)
            {
                previewCtrl.Document = billsPrint.PrintDocD;
            }
            previewCtrl.InvalidatePreview();
        }
    }
}
