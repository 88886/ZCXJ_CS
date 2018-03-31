using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using Newtonsoft.Json;

namespace ZCXJ_CS.Domain
{
    public class User : EntityBase
    {
        //所属公司
        public int groupId { get; set; }
        //部门（分厂）
        public int deptId { get; set; }
        //车间
        public int workshopId { get; set; }
        //机台
        public int machineId { get; set; }
        //机台编码
        public string machineNo { get; set; }
        //用户编号
        public string userId { get; set; }
        //用户名称
        public string userName { get; set; }
        //用户GUID
        public string userGuid { get; set; }
        //用户卡号
        public string cardNo { get; set; }
        //密码
        public string password { get; set; }
        //对应角色
        public object roleList { get; set; }
        //班组
        public string shift { get; set; }
        //班组编号
        public string shiftNo { get; set; }

        public User()
        {
            cardNo = "NC001";
            userName = "系统管理员";
        }

        public void Clear()
        {
            cardNo = "";
            userName = userId = "";
            roleList = null;
            shift = shiftNo = "";
            password =userGuid = "";
        }

    }
}
