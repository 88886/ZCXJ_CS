using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IEntity, IUnitOfWorkRepository> addEntities;
        private Dictionary<IEntity, IUnitOfWorkRepository> updateEntities;
        private Dictionary<IEntity, IUnitOfWorkRepository> deleteEntities;
        private LogHelper log = LogHelper.GetInstence();

        //内部的数据上下文对象
        public DbContext DataContext
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UnitOfWork(DbContext context)
        {
            addEntities = new Dictionary<IEntity, IUnitOfWorkRepository>();
            updateEntities = new Dictionary<IEntity, IUnitOfWorkRepository>();
            deleteEntities = new Dictionary<IEntity, IUnitOfWorkRepository>();
            this.DataContext = context;
        }

        /// <summary>
        /// 注册新增
        /// </summary>
        public void RegisterAdd(IEntity entity, IUnitOfWorkRepository repository)
        {
            this.addEntities.Add(entity, repository);
        }

        /// <summary>
        /// 注册修改
        /// </summary>
        public void RegisterUpdate(IEntity entity, IUnitOfWorkRepository repository)
        {
            this.updateEntities.Add(entity, repository);
        }

        /// <summary>
        /// 注册删除
        /// </summary>
        public void RegisterDelete(IEntity entity, IUnitOfWorkRepository repository)
        {
            this.deleteEntities.Add(entity, repository);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public bool Commit()
        {
            try
            {
                //关闭EF的自动跟踪
                DataContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (IEntity entity in this.addEntities.Keys)
                {
                    this.addEntities[entity].PersistAddItem(entity);
                }

                foreach (IEntity entity in this.updateEntities.Keys)
                {
                    this.updateEntities[entity].PersistUpdateItem(entity);
                }

                foreach (IEntity entity in this.deleteEntities.Keys)
                {
                    this.deleteEntities[entity].PersistDeleteItem(entity);
                }
                //保存
                DataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                var Errors = DataContext.GetValidationErrors();
                List<string> Errlst = new List<string>();
                if (Errors.Count() > 0)
                {
                    Errlst = Errors.Select(e => string.Join(";", e.ValidationErrors.Select(v => v.PropertyName + ":" + v.ErrorMessage).ToList())).ToList();
                }
                log.Error(GetInnerExceptionMessage(ex) + ":\n" + string.Join("\n", Errlst));
                return false;
            }
            finally
            {
                //清除Dictionary
                this.deleteEntities.Clear();
                this.addEntities.Clear();
                this.updateEntities.Clear();
                //重新打开EF的自动跟踪
                DataContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        /// <summary>
        /// 获取异常消息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static string GetInnerExceptionMessage(Exception ex)
        {
            string Message = string.Empty;
            if (ex.InnerException != null)
            {
                Message = GetInnerExceptionMessage(ex.InnerException);
            }
            else
            {
                Message = ex.Message;
            }
            return Message;
        }
    }
}
