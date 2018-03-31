using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Utilities;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Infrastructure;

namespace ZCXJ_CS.UI
{
    public partial class DlgFactorVerify
    {
        /// <summary>
        /// 工艺指标表格
        /// </summary>
        private ListGridView<TechIndicatorss> IndicatorssGridView;

        /// <summary>
        /// 质量控制表格
        /// </summary>
        private ListGridView<TechQualityControls> QualityControlsGridView;

        /// <summary>
        /// 物料表格
        /// </summary>
        private ListGridView<TechMaterials> MaterialsGridView;

        /// <summary>
        /// 工装表格
        /// </summary>
        private ListGridView<TechProduceToolss> ProduceToolssGridView;

        /// <summary>
        /// 弹出窗口
        /// </summary>
        private DlgBase dlgverify;

        #region ***物料装配数据操作相关***
        /// <summary>
        /// 物料装配表格
        /// </summary>
        private void InitMaterialsGridView()
        {
            dlgverify.Text = "扫码校验 - 物料装配列表";
            dlgverify.BottomPane.Controls.Clear();
            dlgverify.BaseMainPanel.Controls.Clear();
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("取消", "Cancel", 0, null, DialogResult.Cancel));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("下一步", "Next", 0, MaterialsNext_Click));
            MaterialsGridView = new ListGridView<TechMaterials>();
            MaterialsGridView.Dock = DockStyle.Fill;
            MaterialsGridView.PageSize = 10;
            MaterialsGridView.AllowUserToAddRows = false;
            MaterialsGridView.GridView.AllowUserToResizeRows = false;
            MaterialsGridView.Captions = TechMaterials.GetCaptions();
            MaterialsGridView.ReadOnly = true;
            MaterialsGridView.DataList = Bom.mesTechMaterials;
            MaterialsGridView.DataRefresh();
            MaterialsGridView.BindingContextChanged += MaterialsGridView_BindingContextChanged;
            MaterialsGridView.DataBindingComplete += MaterialsGridView_DataBindingComplete;
            dlgverify.BaseMainPanel.Controls.Add(MaterialsGridView);
            GridViewType = ListGridViewType.MaterialsGridView;
        }

        /// <summary>
        /// 物料条码数据校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dlgverify.BottomPane.Controls.ContainsKey("Next"))
            {
                bool NextEnable = SetRowBackColorCompareCellValue(MaterialsGridView.GridView, "materialCode");
                dlgverify.Invoke(new Action(() =>
                {
                    dlgverify.BottomPane.Controls["Next"].Enabled = NextEnable;
                }));
            }
        }

        /// <summary>
        /// 数据绑定完成时调整列宽度
        /// </summary>
        private void MaterialsGridView_BindingContextChanged(object sender, EventArgs e)
        {
            MaterialsGridView.GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MaterialsGridView.GridView.Columns["materialNo"].Width = 280;
            MaterialsGridView.GridView.Columns["materialName"].Width = 280;
            //MaterialsGridView.GridView.Columns["materialCode"].Width = 200;
        }

        /// <summary>
        /// 物料下一步
        /// </summary>
        private void MaterialsNext_Click(object sender, EventArgs e)
        {
            Bom.mesTechMaterials = MaterialsGridView.DataList;
            InitProduceToolssGridView();
        }
        #endregion

        #region ***生产工装数据操作相关***
        /// <summary>
        /// 工装工装表格
        /// </summary>
        private void InitProduceToolssGridView()
        {
            dlgverify.Text = "扫码校验 - 生产工装列表";
            dlgverify.BottomPane.Controls.Clear();
            dlgverify.BaseMainPanel.Controls.Clear();
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("取消", "Cancel", 0, null, DialogResult.Cancel));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("下一步", "Next", 0, ProduceToolssNext_Click));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("上一步", "Preview", 0, ProduceToolssPreview_Click));
            ProduceToolssGridView = new ListGridView<TechProduceToolss>();
            ProduceToolssGridView.Dock = DockStyle.Fill;
            ProduceToolssGridView.PageSize = 10;
            ProduceToolssGridView.AllowUserToAddRows = false;
            ProduceToolssGridView.GridView.AllowUserToResizeRows = false;
            ProduceToolssGridView.Captions = TechProduceToolss.GetCaptions();
            ProduceToolssGridView.ReadOnly = true;
            ProduceToolssGridView.DataList = Bom.mesTechProduceToolss;
            ProduceToolssGridView.DataRefresh();
            ProduceToolssGridView.BindingContextChanged += ProduceToolssGridView_BindingContextChanged;
            ProduceToolssGridView.DataBindingComplete += ProduceToolssGridView_DataBindingComplete;
            dlgverify.BaseMainPanel.Controls.Add(ProduceToolssGridView);
            GridViewType = ListGridViewType.ProduceToolssGridView;
        }

        /// <summary>
        /// 工装条码数据校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProduceToolssGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dlgverify.BottomPane.Controls.ContainsKey("Next"))
            {
                bool NextEnable = SetRowBackColorCompareCellValue(ProduceToolssGridView.GridView, "produceToolsCode");
                dlgverify.Invoke(new Action(() =>
                {
                    dlgverify.BottomPane.Controls["Next"].Enabled = NextEnable;
                }));
            }
        }

        /// <summary>
        /// 数据绑定结束后设置列宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProduceToolssGridView_BindingContextChanged(object sender, EventArgs e)
        {
            ProduceToolssGridView.GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;            
            ProduceToolssGridView.GridView.Columns["toolsNo"].Width = 180;
            ProduceToolssGridView.GridView.Columns["toolsName"].Width = 150;
            ProduceToolssGridView.GridView.Columns["ToolsTypeName"].Width = 100;
            ProduceToolssGridView.GridView.Columns["toolsType"].DisplayIndex = 4;
            ProduceToolssGridView.GridView.Columns["toolsType"].Visible = false;
        }

        /// <summary>
        /// 工装下一步
        /// </summary>
        private void ProduceToolssNext_Click(object sender, EventArgs e)
        {
            Bom.mesTechProduceToolss = ProduceToolssGridView.DataList;
            InitIndicatorssGridView();
        }

        /// <summary>
        /// 工装上一步
        /// </summary>
        private void ProduceToolssPreview_Click(object sender, EventArgs e)
        {
            Bom.mesTechProduceToolss = ProduceToolssGridView.DataList;
            InitMaterialsGridView();
        }
        #endregion

        #region ***工艺数据操作相关***
        /// <summary>
        /// 加载工艺指标表格
        /// </summary>
        private void InitIndicatorssGridView()
        {
            dlgverify.Text = "扫码校验 - 工艺控制指标";
            IndicatorssGridView = new ListGridView<TechIndicatorss>();
            IndicatorssGridView.Dock = DockStyle.Fill;
            IndicatorssGridView.PageSize = 10;
            IndicatorssGridView.AllowUserToAddRows = false;
            IndicatorssGridView.GridView.AllowUserToResizeRows = false;
            IndicatorssGridView.Captions = TechIndicatorss.GetCaptions();
            IndicatorssGridView.ReadOnly = true;
            IndicatorssGridView.DataList = Bom.mesTechIndicatorss;
            IndicatorssGridView.DataRefresh();
            IndicatorssGridView.BindingContextChanged += IndicatorssGridView_BindingContextChanged;
            dlgverify.BottomPane.Controls.Clear();
            dlgverify.BaseMainPanel.Controls.Clear();
            dlgverify.BaseMainPanel.Controls.Add(IndicatorssGridView);
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("取消", "Cancel", 0, null, DialogResult.Cancel));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("下一步", "Next", 0, IndicatorssNext_Click));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("上一步", "Preview", 0, IndicatorssPreview_Click));
            GridViewType = ListGridViewType.IndicatorssGridView;
        }

        private void IndicatorssGridView_BindingContextChanged(object sender, EventArgs e)
        {
            IndicatorssGridView.GridView.Columns["indicatorsName"].Width = 200;
        }

        /// <summary>
        /// 工艺下一步
        /// </summary>
        private void IndicatorssNext_Click(object sender, EventArgs e)
        {
            InitQualityControlsGridView();
        }
        /// <summary>
        /// 工艺上一步
        /// </summary>
        private void IndicatorssPreview_Click(object sender, EventArgs e)
        {
            InitProduceToolssGridView();
        }
        #endregion

        #region ***质量控制数据操作相关***
        /// <summary>
        /// 加载质量控制表格
        /// </summary>
        private void InitQualityControlsGridView()
        {
            dlgverify.Text = "扫码校验 - 质量控制指标";
            QualityControlsGridView = new ListGridView<TechQualityControls>();
            QualityControlsGridView.Dock = DockStyle.Fill;
            QualityControlsGridView.PageSize = 10;
            QualityControlsGridView.AllowUserToAddRows = false;
            QualityControlsGridView.GridView.AllowUserToResizeRows = false;
            QualityControlsGridView.Captions = TechQualityControls.GetCaptions();
            QualityControlsGridView.ReadOnly = true;
            QualityControlsGridView.DataList = Bom.mesTechQualityControls;
            QualityControlsGridView.DataRefresh();
            QualityControlsGridView.BindingContextChanged += QualityControlsGridView_BindingContextChanged;
            dlgverify.BottomPane.Controls.Clear();
            dlgverify.BaseMainPanel.Controls.Clear();
            dlgverify.BaseMainPanel.Controls.Add(QualityControlsGridView);
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("取消", "Cancel", 0, null, DialogResult.Cancel));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn(IsWritePlcData ? "下载控制参数到机台" : "确认", "Finish", 0, QualityControlsFinish_Click));
            dlgverify.BottomPane.Controls.Add(dlgverify.GenComandBtn("上一步", "Preview", 0, QualityControlsPreview_Click));
            GridViewType = ListGridViewType.QualityControlsGridView;
        }

        private void QualityControlsGridView_BindingContextChanged(object sender, EventArgs e)
        {
            QualityControlsGridView.GridView.Columns["indicatorsName"].Width = 200;
        }

        /// <summary>
        /// 质量控制完成
        /// </summary>
        private void QualityControlsFinish_Click(object sender, EventArgs e)
        {
            if (IsWritePlcData)
            {
                //TODO 控制数据下载到设备
            }
            dlgverify.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// 质量控制上一步
        /// </summary>
        private void QualityControlsPreview_Click(object sender, EventArgs e)
        {
            InitIndicatorssGridView();
        }
        #endregion

        /// <summary>
        /// 对比并设置单元格的值
        /// </summary>
        /// <param name="GridView">数据表</param>
        /// <param name="CompareColumnName">对比行</param>
        /// <param name="ChangeColumnName">设置值的行</param>
        /// <param name="data"></param>
        private bool GridCellCompareSetValue(
            DataGridView GridView, 
            string CompareColumnName, 
            string ChangeColumnName, 
            string data)
        {
            var Rows = GridView.Rows;
            for (int i = 0; i < Rows.Count; i++)
            {
                if (data.Contains(Rows[i].Cells[CompareColumnName].Value.ToString()))
                {
                    Rows[i].Cells[ChangeColumnName].Value = data;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 对比数据行的值设置背景色
        /// </summary>
        /// <param name="GridView"></param>
        /// <param name="CompareColumnName"></param>
        private bool SetRowBackColorCompareCellValue(
            DataGridView GridView,
            string CompareColumnName
            )
        {
            bool ret = true;
            for (int i = 0; i < GridView.RowCount; i++)
            {
                if (Convert.ToString(GridView.Rows[i].Cells[CompareColumnName].Value).Length > 0)
                {
                    GridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    GridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    ret = false;
                }
            }
            return ret;
        }
    }
}
