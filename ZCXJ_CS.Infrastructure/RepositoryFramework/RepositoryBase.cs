using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using ZCXJ_CS.Utilities;


namespace ZCXJ_CS.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T>, IUnitOfWorkRepository where T : EntityBase
    {
        //数据上下文
        public DbContext context = null;

        //日志对象
        private LogHelper log = null;

        //工作单元
        private IUnitOfWork unitOfWork = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public RepositoryBase(DbContext context)
        {
            this.context = context;
            log = LogHelper.GetInstence();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">对应工作单元</param>
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            context = unitOfWork.DataContext;
            log = LogHelper.GetInstence();
        }

        /// <summary>
        /// 获取实体（通过索引器）
        /// </summary>
        /// <param name="Key">id</param>
        /// <returns></returns>
        public T this[string key]
        {
            get
            {
                return Get(t => t.Key == key);
            }
            set
            {
                if (Get(t => t.Key == key) == null)
                {
                    this.Add(value);
                }
                else
                {
                    this.Update(value);
                }
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns>实体对象集合</returns>
        public IEnumerable<T> GetList(Expression<Func<T, bool>> exp = null)
        {
            try
            {
                if (exp != null)
                {
                    return context.Set<T>().Where<T>(exp);
                }
                return context.Set<T>();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="exp">表达式</param>
        /// <returns>实体对象</returns>
        public T Get(Expression<Func<T, bool>> exp)
        {
            try
            {
                return context.Set<T>().FirstOrDefault<T>(exp);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T entity)
        {
            if (unitOfWork != null)
            {
                unitOfWork.RegisterAdd(entity, this);
                return true;
            }
            else
            {
                return Add(entity, true);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T entity)
        {
            if (unitOfWork != null)
            {
                unitOfWork.RegisterUpdate(entity, this);
                return true;
            }
            else
            {
                return Update(entity, true);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(T entity)
        {
            if (unitOfWork != null)
            {
                unitOfWork.RegisterDelete(entity, this);
                return true;
            }
            else
            {
                return Delete(entity, true);
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Expression<Func<T, bool>> exp)
        {
            try
            {
                if (null != context.Set<T>().FirstOrDefault<T>(exp))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        public int GetCounts(Expression<Func<T, bool>> exp = null)
        {
            try
            {
                if (exp != null)
                {
                    return context.Set<T>().Count<T>(exp);
                }
                return context.Set<T>().Count<T>();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return -1;
            }
        }

        #region 实际调用的函数
        private bool Add(T entity, bool isSaved)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Add(entity);
            if (isSaved)
            {
                return SaveChanges();
            }
            return true;
        }

        private bool Update(T entity, bool isSaved)
        {
            context.Set<T>().Attach(entity);
            context.Entry<T>(entity).State = EntityState.Modified;
            if (isSaved)
            {
                return SaveChanges();
            }
            return true;
        }

        private bool Delete(T entity, bool isSaved)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
            if (isSaved)
            {
                return SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        /// <returns></returns>
        private bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message + "\r\n" + string.Join("\r\n",
                    context.GetValidationErrors()
                    .Select(a => string.Join(",", a.ValidationErrors
                    .Select(b => b.ErrorMessage).ToList())).ToList()));
                return false;
            }
        }
        #endregion

        #region IUnitOfWorkRepository接口成员函数

        public virtual void PersistAddItem(IEntity item)
        {
            Add((T)item, false);
        }
       
        public virtual void PersistUpdateItem(IEntity item)
        {
            Update((T)item, false);
        }

        public virtual void PersistDeleteItem(IEntity item)
        {
            Delete((T)item, false); 
        }

#endregion

    }
}
