using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Infrastructure;
using System.ComponentModel;
using System.Threading;

namespace ZCXJ_CS.UI
{
    public enum ListGridViewType
    {
        None,
        IndicatorssGridView,
        QualityControlsGridView,
        MaterialsGridView,
        ProduceToolssGridView
    }
    public partial class DlgFactorVerify
    {
        /// <summary>
        /// 制品Bom实体
        /// </summary>
        public ProductBom Bom = null;
        /// <summary>
        /// Bom管理对象
        /// </summary>
        public BomManager BomManager;
        /// <summary>
        /// 当前数据表对象
        /// </summary>
        ListGridViewType GridViewType;
        /// <summary>
        /// 是否将控制参数写入Plc
        /// </summary>
        bool IsWritePlcData = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlgFactorVerify()
        {
            dlgverify = new DlgBase();
            Bom = new ProductBom();
            BomManager = new BomManager();
            GridViewType = ListGridViewType.None;
            dlgverify.Size = new System.Drawing.Size(900, 550);
        }

        /// <summary>
        /// 显示生产校验对话框
        /// </summary>
        /// <param name="wt">待校验工单</param>
        /// <returns>通过校验返回DialogResult.Yes</returns>
        public DialogResult Show(WorkTicket wt, bool isWritePlcData = false)
        {
            if (wt == null)
                return DialogResult.None;
            Bom = wt.Bom;
            IsWritePlcData = isWritePlcData;
            InitMaterialsGridView();
            GlobalData.SpScanner.OnDataReceived += SerialPortHelper_OnDataReceived;
            DialogResult result = dlgverify.ShowDialog();
            GlobalData.SpScanner.OnDataReceived -= SerialPortHelper_OnDataReceived;
            //将BOM赋值给当前的工单
            if (result == DialogResult.Yes)
            {
                GlobalData.Log.Debug("Material:{0}", Bom.mesTechMaterials[0].materialCode);
            }
            return result;
        }

        /// <summary>
        /// 条码枪数据接收响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data">数据</param>
        private void SerialPortHelper_OnDataReceived(object sender, byte[] data)
        {
            string Receive = Encoding.Default.GetString(data).Replace("\r\n","");
            switch (GridViewType)
            {
                case ListGridViewType.MaterialsGridView:
                    if (GridCellCompareSetValue(MaterialsGridView.GridView, "materialNo", "materialCode", Receive))
                    {
                        Bom.mesTechMaterials = MaterialsGridView.DataList;
                        MaterialsGridView_DataBindingComplete(null, null);
                    }
                    break;
                case ListGridViewType.ProduceToolssGridView:
                    if (GridCellCompareSetValue(ProduceToolssGridView.GridView, "toolsNo", "produceToolsCode", Receive))
                    {
                        Bom.mesTechProduceToolss = ProduceToolssGridView.DataList;
                        ProduceToolssGridView_DataBindingComplete(null, null);
                    }
                    break;
            }
            GlobalData.Log.Info(GlobalData.SpScanner.GetPortName() + "扫入条码:" + Receive);
        }
    }
}
