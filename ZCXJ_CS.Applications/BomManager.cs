using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Repository;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Applications
{
    public class BomManager
    {
        public UnitOfWork UnitOfWorkBOMTech = null;
        public UnitOfWork UnitOfWorkBOMCache = null;
        public DbContext context = new SQLiteContext();
        RepositoryBase<BomTech> rep = null;
        RepositoryBase<BomCache> repcache = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BomManager()
        {
            UnitOfWorkBOMTech = new UnitOfWork(context);
            UnitOfWorkBOMCache = new UnitOfWork(context);
            rep = new RepositoryBase<BomTech>(UnitOfWorkBOMTech);
            repcache = new RepositoryBase<BomCache>(UnitOfWorkBOMCache);
        }

        /// <summary>
        /// 获取指定工艺制品Bom
        /// </summary>
        /// <param name="planNo"></param>
        /// <returns></returns>
        public List<BomTech> GetByNo(string prodNo,string machineNo,string techNo)
        {
            //TODO 启用工艺路线编号
            return rep.GetList(bt => (bt.prodNo == prodNo && bt.machineNo == machineNo)).ToList();            
            //return rep.GetList(bt => (bt.prodNo == prodNo && bt.machineNo == machineNo && bt.techNo == techNo)).ToList();
        }

        /// <summary>
        /// 获取制品施工Bom标准项
        /// </summary>
        /// <param name="prodNo">制品编号</param>
        /// <param name="machineNo">设备编号</param>
        /// <param name="techNo">工艺编号</param>
        /// <returns></returns>
        public bool GetProductBomStandard(string prodNo, string machineNo, string techNo, ref ProductBom bom, bool IsNetConnected = true)
        {
            bom = new ProductBom();
            bool ret = false;
            List<BomTech> lst = GetByNo(prodNo, machineNo, techNo);
            if (lst != null && lst.Count > 0)
            {
                foreach (var model in lst)
                {
                    bom.GetType().GetProperty(model.dataType).SetValue(bom, model.dataJson, null);
                }
            }
            ret = bom != null && bom.Materials != null && bom.Materials.Count() > 0;
            if (!ret && IsNetConnected)
            {
                var requestData = new
                {
                    machineNo,
                    prodNo,
                    techNo
                };
                string result = HttpDataTrans.DataTrans(GlobalData.CfgHelper.GetKeyValue("API_DownProductBom"), "", RequestType.POST, requestData);
                if (!string.IsNullOrEmpty(result))
                {
                    bom = JsonResult<ProductBom>.ConvertToModel(result);
                    ret = bom != null && bom.Materials != null && bom.Materials.Count() > 0;
                    if (ret)
                    {
                        SaveProductBomStandard(bom, prodNo, machineNo, techNo);
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 保存制品施工Bom标准项
        /// </summary>
        /// <param name="bom">bom实体</param>
        public bool SaveProductBomStandard(ProductBom bom, string prodNo, string machineNo, string techNo)
        {
            List<BomTech> localBomTech = rep.GetList(bt => (bt.prodNo == prodNo && bt.machineNo == machineNo && bt.techNo == techNo)).ToList();
            bool IsExists = (localBomTech != null && localBomTech.Count > 0);
            foreach (var p in bom.GetType().GetProperties())
            {
                if (p.PropertyType.Name.ToLower() == "string")
                {
                    BomTech Model = new BomTech();
                    if (IsExists)
                    {
                        Model = localBomTech.FirstOrDefault(i => i.dataType == p.Name);
                        if (Model != null && !string.IsNullOrEmpty(Model.prodNo))
                        {
                            Model.dataJson = p.GetValue(bom, null).ToString();
                            rep.Update(Model);
                        }
                        else
                        {
                            Model = new BomTech();
                            Model.techNo = techNo;
                            Model.machineNo = machineNo;
                            Model.prodNo = prodNo;
                            Model.dataType = p.Name;
                            Model.dataJson = p.GetValue(bom, null).ToString();
                            rep.Add(Model);
                        }
                    }
                    else
                    {
                        Model = new BomTech(); 
                        Model.techNo = techNo;
                        Model.machineNo = machineNo;
                        Model.prodNo = prodNo;
                        Model.dataType = p.Name;
                        Model.dataJson = p.GetValue(bom, null).ToString();
                        rep.Add(Model);
                    }
                }
            }
            return UnitOfWorkBOMTech.Commit();
        }
        /// <summary>
        /// 获取计划缓存Bom,如无缓存，则返回Bom标准
        /// </summary>
        /// <param name="planNo">工单号</param>
        /// <param name="prodNo">制品编号</param>
        /// <param name="machineNo">设备编号</param>
        /// <param name="techNo">工艺编号</param>
        /// <param name="bom">Bom实体</param>
        /// <returns></returns>
        public bool GetPlanBomCache(string planNo, string prodNo, string machineNo, string techNo, ref ProductBom bom, bool IsNetConnected = true)
        {
            bool ret = false;
            bom = bom == null ? new ProductBom() : bom;
            List<BomCache> lst = repcache.GetList(a => a.planNo == planNo).ToList();
            if (lst != null && lst.Count > 0)
            {
                foreach (var model in lst)
                {
                    bom.GetType().GetProperty(model.dataType).SetValue(bom, model.dataJson, null);
                }
            }
            ret = bom != null && bom.Materials != null && bom.Materials.Count() > 0;
            if (!ret)
                ret = GetProductBomStandard(prodNo, machineNo, techNo, ref bom, IsNetConnected);
            return ret;
        }
        
        /// <summary>
        /// 保存制品施工Bom标准项
        /// </summary>
        /// <param name="bom">bom实体</param>
        public bool SavePlanBomCache(ProductBom bom, string planNo)
        {
            List<BomCache> localBomCache = repcache.GetList(i => i.planNo == planNo).ToList();
            bool IsExists = (localBomCache != null && localBomCache.Count > 0);
            foreach (var p in bom.GetType().GetProperties())
            {
                if (p.PropertyType.Name.ToLower() == "string")
                {
                    BomCache Model = new BomCache();
                    if (IsExists)
                    {
                        Model = localBomCache.FirstOrDefault(i => i.dataType == p.Name);
                        if (Model != null && !string.IsNullOrEmpty(Model.planNo))
                        {
                            Model.dataJson = p.GetValue(bom, null).ToString();
                            repcache.Update(Model);
                        }
                        else
                        {
                            Model = new BomCache();
                            Model.planNo = planNo;
                            Model.dataType = p.Name;
                            Model.dataJson = p.GetValue(bom, null).ToString();
                            repcache.Add(Model);
                        }
                    }
                    else
                    {
                        Model = new BomCache();
                        Model.planNo = planNo;
                        Model.dataType = p.Name;
                        Model.dataJson = p.GetValue(bom, null).ToString();
                        repcache.Add(Model);
                    }
                }
            }
            return UnitOfWorkBOMCache.Commit();
        }
    }
}
