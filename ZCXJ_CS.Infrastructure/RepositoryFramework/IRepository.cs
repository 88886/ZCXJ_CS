using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Entity;


namespace ZCXJ_CS.Infrastructure
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// 索引器获取实体
        /// </summary>
        /// <param name="Key">id</param>
        /// <returns></returns>
        T this[string key] 
        { get; set; }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> GetList(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> exp);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(T entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(T entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(T entity);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Expression<Func<T, bool>> exp);

        /// <summary>
        /// 获取记录数
        /// </summary>
        int GetCounts(Expression<Func<T, bool>> exp = null);

    }
}
