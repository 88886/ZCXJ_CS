using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ZCXJ_CS.Infrastructure
{
    public interface IUnitOfWork
    {
        //内部的数据上下文对象
        DbContext DataContext { get; set; }

        /// <summary>
        /// 注册新增
        /// </summary>
        void RegisterAdd(IEntity entity, IUnitOfWorkRepository repository);

        /// <summary>
        /// 注册修改
        /// </summary>
        void RegisterUpdate(IEntity entity, IUnitOfWorkRepository repository);

        /// <summary>
        /// 注册删除
        /// </summary>
        void RegisterDelete(IEntity entity, IUnitOfWorkRepository repository);

        /// <summary>
        /// 提交整个工作单元的事务
        /// </summary>
        bool Commit();
    }
}
