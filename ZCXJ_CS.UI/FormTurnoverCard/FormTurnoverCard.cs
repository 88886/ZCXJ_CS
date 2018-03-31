using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZCXJ_CS.Utilities;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Applications;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using BillPrintEngine;


namespace ZCXJ_CS.UI
{
    public partial class FormTurnoverCard : FormBase
    {
        //当前工单控件
        public ItemWorkTicket ItemWT = null;
        //周转卡管理者对象
        public TurnOverCardManager TCardManager = null;
        //临时工单对象，用于与全局工单对象进行对比
        private WorkTicket wt = new WorkTicket();
        //打印类对象
        BillsPrint billsPrint = null;

        //构造函数
        public FormTurnoverCard()
        {
            InitializeComponent();
            wt = GlobalData.WtManager.CurWorkTicket;
            ItemWT = new ItemWorkTicket(wt);
            ItemWT.Dock = DockStyle.Fill;
            ItemWT.ShowButtons(false);
            panelCurWT.Controls.Add(ItemWT);
            TCardManager = new TurnOverCardManager();
            TCardManager.OnUpTurnOverCard += new DataTransCompletedDelegate(OnUpTurnOverCard);
            GlobalData.SpScanner.OnDataReceived += SpScanner_OnDataReceived;
            GlobalData.OnCurWorkTicketChanged += GlobalData_OnCurWorkTicketChanged;
        }
        /// <summary>
        /// 当前工单变更
        /// </summary>
        private void GlobalData_OnCurWorkTicketChanged(object sender, EventArgs e)
        {
            wt = GlobalData.WtManager.CurWorkTicket;
            LoadTurnOverCardList(wt);
        }

        /// <summary>
        /// 上传周转卡结果处理
        /// </summary>
        /// <param name="result"></param>
        private void OnUpTurnOverCard(string result,object param)
        {
            if (JsonResult<object>.IsOK(result))
            {
                GlobalData.Log.Info("周转卡信息上传成功.");
                DlgBox.Show("周转卡信息上传成功！");
            }
            else
            {
                GlobalData.Log.Error("周转卡信息上传失败.");
                DlgBox.Show("周转卡信息上传失败！");
            }
        }

        /// <summary>
        /// 刷新界面显示
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            wt = GlobalData.WtManager.CurWorkTicket;
            LoadTurnOverCardList(wt);
        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ItemWT != null)
                {
                    ItemWT.ReLoadWT(wt);
                    ItemWT.SetSelected(ItemWT.IsSelected);
                }
                else
                {
                    GlobalData.Log.Error("出现ItemWT==null异常");
                }
            }
            catch (Exception ex)
            {
                GlobalData.Log.Error("定时器事件异常：" + ex.ToString());
            }
        }
        DlgBase dlg = null;
        GetToolBox box = null;
        /// <summary>
        /// 报产（生成周转卡）
        /// </summary>
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (GlobalData.WtManager.CurWorkTicket.planNo == string.Empty)
            {
                DlgBox.Show("当前没有可报产的生产工单。");
                return;
            }
            dlg = new DlgBase();
            box = new GetToolBox();
            dlg.Size = new Size(330, 220);
            dlg.Text = "报产确认";
            box.Dock = DockStyle.Fill;
            box.Count = (int)GlobalData.WtManager.CurWorkTicket.completeAmount;
            box.OnFillTextChange += Box_OnFillTextChange;
            dlg.BaseMainPanel.Controls.Add(box);
            dlg.BottomPane.Controls.Add(dlg.GenComandBtn("取消", "Cancel", 0, null, DialogResult.Cancel));
            dlg.BottomPane.Controls.Add(dlg.GenComandBtn("完成", "Finish", 0, Finish_Click));
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TurnOverCard c = TCardManager.GenCard(GlobalData.WtManager.CurWorkTicket);
                c.stAmount = box.Count;
                c.stToolsNo = box.Tool;
                if (c != null)
                {
                    TCardManager.Add(c);
                    TCardManager.UploadTurnOverCard(c);
                }
                //更新周转卡列表
                LoadTurnOverCardList(GlobalData.WtManager.CurWorkTicket);
            }
        }

        private void Box_OnFillTextChange(bool IsFill)
        {
            if (dlg.BottomPane.Controls.ContainsKey("Finish"))
            {
                dlg.BottomPane.Controls["Finish"].Enabled = IsFill;
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            dlg.DialogResult = DialogResult.OK;
        }
        private void SpScanner_OnDataReceived(object sender, byte[] data)
        {
            string receive = Encoding.UTF8.GetString(data).Replace("\r\n", "");
            if (box != null)
            {
                box.Invoke(new Action(() =>
                {
                    box.Tool = receive;
                }));
            }
        }

        /// <summary>
        /// 载入周转卡列表
        /// </summary>
        private void LoadTurnOverCardList(WorkTicket wt)
        {
            if (wt == null || wt.planNo == null)
            {
                return;
            }
            TCardManager.LoadCardList(wt.planNo);
            UpdateDgvTurnOverCards();
        }

        /// <summary>
        /// 整理周转卡表格
        /// </summary>
        private void UpdateDgvTurnOverCards()
        {
            try
            {
                //数据源
                dgvTurnOverCards.DataSource = null;
                dgvTurnOverCards.DataSource = TCardManager.CardList;
                //全部隐藏
                int colCount = dgvTurnOverCards.Columns.Count;
                for (int i = 0; i < colCount; i++ )
                {
                    dgvTurnOverCards.Columns[i].Visible = false;
                }
                //
                dgvTurnOverCards.Columns["turnoverNo"].Visible = true;
                dgvTurnOverCards.Columns["turnoverNo"].HeaderText = "周转卡号";
                dgvTurnOverCards.Columns["turnoverNo"].Width = 200;

                dgvTurnOverCards.Columns["stToolsNo"].Visible = true;
                dgvTurnOverCards.Columns["stToolsNo"].HeaderText = "储运工装";
                dgvTurnOverCards.Columns["stToolsNo"].Width = 120;

                dgvTurnOverCards.Columns["prodType"].Visible = true;
                dgvTurnOverCards.Columns["prodType"].HeaderText = "制品类型";
                dgvTurnOverCards.Columns["prodType"].Width = 90;

                dgvTurnOverCards.Columns["prodNo"].Visible = true;
                dgvTurnOverCards.Columns["prodNo"].HeaderText = "制品编号";
                dgvTurnOverCards.Columns["prodNo"].Width = 140;

                dgvTurnOverCards.Columns["prodStandard"].Visible = true;
                dgvTurnOverCards.Columns["prodStandard"].HeaderText = "制品规格";
                dgvTurnOverCards.Columns["prodStandard"].Width = 120;

                dgvTurnOverCards.Columns["producePersons"].Visible = true;
                dgvTurnOverCards.Columns["producePersons"].HeaderText = "生产人";
                dgvTurnOverCards.Columns["producePersons"].Width = 80;

                dgvTurnOverCards.Columns["produceTime"].Visible = true;
                dgvTurnOverCards.Columns["produceTime"].HeaderText = "生产时间";
                dgvTurnOverCards.Columns["produceTime"].Width = 140;

                dgvTurnOverCards.Columns["stAmount"].Visible = true;
                dgvTurnOverCards.Columns["stAmount"].HeaderText = "产量";
                dgvTurnOverCards.Columns["stAmount"].Width = 70;
                dgvTurnOverCards.Refresh();
            }
            catch (System.Exception ex)
            {
            	GlobalData.Log.Error("周转卡列表显示异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dgvTurnOverCards.SelectedCells != null && dgvTurnOverCards.SelectedCells.Count > 0)
            {
                ReadyData();
                DlgPreview dlgPreview = new DlgPreview();
                dlgPreview.billsPrint = billsPrint;
                dlgPreview.ShowDialog();
            }
            else
            {
                DlgBox.Show("请先选择需预览的周转卡记录。", "系统提示");
            }
        }

        /// <summary>
        /// 打印周转卡
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTurnOverCards.SelectedCells != null && dgvTurnOverCards.SelectedCells.Count > 0)
            {
                ReadyData();
                billsPrint.PrintDocS.Print();
            }
            else
            {
                DlgBox.Show("请先选择需预览的周转卡记录。", "系统提示");
            }
        }

        private void ReadyData()
        {
            //获取周转卡号
            int index = dgvTurnOverCards.SelectedRows[0].Index;
            if (index == -1)
            {
                DlgBox.Show("没有选中项，请选择要打印或预览的周转卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string turnOverNo = dgvTurnOverCards["turnoverNo", index].Value.ToString();
            TurnOverCard card = (from li in TCardManager.CardList where li.turnoverNo == turnOverNo select li).FirstOrDefault();
            //删除上次打印遗留的模板文件，条形码二维码
            DelTemplateFiles();
            //生成条形码
            CreateBarCode(card.turnoverNo);
            //生成二维码 
            if (!string.IsNullOrEmpty(card.qrCode))
            {
                CreateQRCode(card.qrCode);
            }
            //生成打印文档内容
            string xml = GenBillXmlText(card);
            //生成打印所需的xml文档
            GenBillPrintXmlFile(card.prodType, xml);
            //加载周转卡 
            LoadData(card.prodType);
        }

        private void LoadData(string ProdType)
        {
            billsPrint = new BillsPrint();
            string templatePath = Application.StartupPath + "\\Template\\Bills";
            string[] files = Directory.GetFiles(templatePath, ProdType + "周转卡.xml", SearchOption.TopDirectoryOnly);

            int r = -1;
            foreach (string fileName in files)
            {
                BillDetail billDetail = new BillDetail();
                r = billDetail.LoadTemplate(fileName);
                if (r == 0)
                {
                    //加入单据列表
                    billsPrint.AddBillCollection(billDetail);
                }
                else if (r == -2)
                {
                    DlgBox.Show("无法找到对应的模板文件。", "系统提示");
                    break;
                }
                else
                {
                    DlgBox.Show("加载打印模块过程中出现错误。", "系统提示");
                    break;
                }
            }
        }

        #region 打印准备

        //删除上次打印遗留的模板文件
        private void DelTemplateFiles()
        {
            //删除模板
            string templatePath = Application.StartupPath + "\\Template\\Bills";
            string[] files = Directory.GetFiles(templatePath, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string fileName in files)
            {
                File.Delete(fileName);
            }

            //删除图片
            string picPath = Application.StartupPath + "\\Template";
            string[] picfiles = Directory.GetFiles(picPath, "*.png", SearchOption.TopDirectoryOnly);
            foreach (string fileName in picfiles)
            {
                File.Delete(fileName);
            }
        }

        /// <summary>
        /// 返回生成的Bitmap对象
        /// </summary>
        /// <param name="barcodeContent">条码内容</param>
        /// <param name="barcodeFormat">条码格式</param>
        /// <param name="height">条码高度</param>
        /// <param name="width">宽度高度</param>
        /// <returns></returns>
        public static Bitmap CreateCodePic(string content, BarcodeFormat format, int width, int height)
        {
            try
            {
                BarcodeWriter writer = new BarcodeWriter();
                EncodingOptions options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = width,
                    Height = height
                };
                writer.Options = options;
                writer.Format = format;
                return writer.Write(content);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //生成打印所需的条形码二维码  生成二维码，如果有Logo，则在二维码中添加Logo 
        public void CreateQRCode(string content)
        {
            Bitmap bmp = CreateCodePic(content, BarcodeFormat.QR_CODE, 100, 100);
            if (bmp != null)
            {
                //图片白边
                Bitmap bitmap = new Bitmap(bmp.Width -30, bmp.Height -30);
                Graphics g = Graphics.FromImage(bitmap);
                g.FillRectangle(System.Drawing.Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                g.DrawImage(bmp, new PointF(-15, -15));
                bitmap.Save(Application.StartupPath + "\\Template\\code.png", System.Drawing.Imaging.ImageFormat.Png);
                bitmap.Dispose();
            }
            //bmp.Save(Application.StartupPath + "\\Template\\code.png");
            bmp.Dispose();
        }

        /// <summary>
        /// 生成打印所需的条形码
        /// </summary>
        /// <param name="content"></param>
        private void CreateBarCode(string content)
        {
            Bitmap bmp = CreateCodePic(content, BarcodeFormat.CODE_128, 600, 50);
            bmp.Save(Application.StartupPath + "\\Template\\code_H.png");
            //旋转90度存
            Bitmap bmp_v = Rotate(bmp, 90);
            bmp_v.Save(Application.StartupPath + "\\Template\\code_V.png");            
            bmp.Dispose();
            bmp_v.Dispose();
        }

        //生成打印所需的xml文档
        public bool GenBillPrintXmlFile(string billType, string insertData)
        {
            try
            {
                billType = billType.Replace("/", "");
                string src = Application.StartupPath + "\\Template\\Core\\" + billType + "周转卡_Base.xml";
                string des = Application.StartupPath + "\\Template\\Bills\\" + billType + "周转卡.xml";

                File.Copy(src, des, true);
                string fileBase = "";
                using (StreamReader sr = new StreamReader(des))
                {
                    fileBase = sr.ReadToEnd();
                }
                using (StreamWriter sw = new StreamWriter(des))
                {
                    sw.Write(fileBase.Replace("$BillData$", insertData));
                }
                return true;
            }
            catch (System.Exception ex)
            {
                GlobalData.Log.Error("生成打印文档过程中出现异常：" + ex.ToString());
                return false;
            }
        }

        //生成打印模板文档 
        private string GenBillXmlText(TurnOverCard card)
        {
            try
            {
                if (card != null)
                {
                    StringBuilder sb = new StringBuilder(1024);
                    sb.AppendLine(@"<单据>");
                    sb.AppendLine("<业务回单>");
                    sb.Append("<制品类别_V>" + card.prodType + "</制品类别_V>");
                    sb.Append("<制品规格_V>" + card.prodStandard + "</制品规格_V>");
                    sb.Append("<制品ID_V>" + card.prodNo + "</制品ID_V>");
                    sb.Append("<物料1_V>" + card.materialNo1 + "</物料1_V>");
                    sb.Append("<物料2_V>" + card.materialNo2 + "</物料2_V>");
                    sb.Append("<物料3_V>" + card.materialNo3 + "</物料3_V>");
                    sb.Append("<物料4_V>" + card.materialNo4 + "</物料4_V>");
                    sb.Append("<工装1_V>" + card.produceTool1 + "</工装1_V>");
                    sb.Append("<工装2_V>" + card.produceTool2 + "</工装2_V>");
                    sb.Append("<工装3_V>" + card.produceTool3 + "</工装3_V>");
                    sb.Append("<工装4_V>" + card.produceTool4 + "</工装4_V>");
                    sb.Append("<贮运工装_V>" + card.stToolsNo + "</贮运工装_V> ");
                    sb.Append("<保质时间_V>" + card.shelfLifeTime + "</保质时间_V>");
                    sb.Append("<载料数量_V>" + card.stAmount + "</载料数量_V>");
                    sb.Append("<生产机台_V>" + card.machineNo + "</生产机台_V>");
                    sb.Append("<生产人员_V>" + card.producePersons + "</生产人员_V>");
                    sb.Append("<适用在制品_V>" + card.applyProdSpecList + "</适用在制品_V>");
                    sb.Append("<制品自检_V>" + card.prodSelfCheck + "</制品自检_V>");
                    sb.Append("<生产时间_V>" + card.produceTime + "</生产时间_V>");
                    sb.Append("<是否首件_V>" + card.isFirstProd + "</是否首件_V>");
                    sb.Append("<质检信息_V>" + card.checkInfo + "</质检信息_V>");
                    sb.Append("<技术意见_V>" + card.technologyNotion + "</技术意见_V>");
                    sb.Append("<建议存放库位_V>" + card.adviseStoreArea + "</建议存放库位_V> ");
                    sb.Append("<建议使用机台_V>" + card.adviseUseMachine + "</建议使用机台_V>");
                    sb.Append("<产地_V>" + card.produceAddress + "</产地_V>");
                    sb.Append("<使用时间_V>" + card.startUseTime + "</使用时间_V>");
                    sb.Append("<使用地_V>" + card.useAddress + "</使用地_V>");
                    sb.Append("<二维码_1>code.png</二维码_1>");
                    sb.Append("<二维码_2>code.png</二维码_2>");
                    sb.Append("<条形码_1>code_H.png</条形码_1>");
                    sb.Append("<条形码_2>code_V.png</条形码_2>");
                    sb.AppendLine("</业务回单>");
                    sb.AppendLine("</单据>");
                    return sb.ToString();
                }
                return "";
            }
            catch (System.Exception ex)
            {
                GlobalData.Log.Error("生成打印模板文档过程中出现异常：" + ex.ToString());
                return "";
            }
        }

        #endregion

        #region 图片旋转函数
        /// <summary>
        /// 以逆时针为方向对图像进行旋转
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">旋转角度[0,360](前台给的)</param>
        /// <returns></returns>
        public static Bitmap Rotate(Bitmap b, int angle)
        {
            angle = angle % 360;
            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            return dsImage;
        }

        #endregion 图片旋转函数

        


    }
}
