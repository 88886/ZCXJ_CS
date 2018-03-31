using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.Infrastructure
{
    public abstract class EntityBase : Object, IEntity
    {
        /// <summary>
        /// 实体键
        /// </summary>
        [JsonProperty]
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty]
        public string Remark
        {
            get;
            set;
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        [JsonProperty]
        public int UpdateState
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty]
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty]
        public DateTime UpdateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 是否使用
        /// </summary>
        [JsonProperty]
        public int IsUsed
        {
            get;
            set;
        }

        /// <summary>
        /// 显示次序
        /// </summary>
        [JsonProperty]
        public int DisplayOrder
        {
            get;
            set;
        }

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        protected EntityBase()
            : this(null)
        {
        }

        /// <summary>
        /// 重载构造函数
        /// </summary>
        /// <param name="Key">标识实体的键</param>
        protected EntityBase(string key)
        {
            Key = key;
            if (string.IsNullOrEmpty(Key))
            {
                Key = EntityBase.NewKey();
            }
            Remark = string.Empty;
            CreateTime = UpdateTime = DateTime.Now;
            UpdateState = 0;
            IsUsed = 0;
            DisplayOrder = -1;
        }

        /// <summary>
        /// 生成新键
        /// </summary>
        /// <returns></returns>
        public static string NewKey()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 相等性判断（同一个对象引用）
        /// </summary>
        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase && this == (EntityBase)entity;
        }

        /// <summary>
        /// == 操作符重载（若key相等则认为两者相等）
        /// </summary>
        public static bool operator ==(EntityBase base1, EntityBase base2)
        {
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            if (base1.Key != base2.Key)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ！= 操作符重载
        /// </summary>
        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return (!(base1 == base2));
        }

        /// <summary>
        /// 重载GetHashCode
        /// </summary>
        /// <returns>哈希值.</returns>
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        /// <summary>
        /// 重载ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonHelper.ToJson(this);
        }

    }
}
