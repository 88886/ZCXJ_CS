using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Repository;

namespace ZCXJ_CS.Applications
{
    public class UserManager
    {
        public UnitOfWork UnitOfWorkWT = null;
        public DbContext context = new SQLiteContext();
        RepositoryBase<User> rep = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserManager()
        {
            UnitOfWorkWT = new UnitOfWork(context);
            rep = new RepositoryBase<User>(UnitOfWorkWT);
        }

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="days">卡号</param>
        /// <returns></returns>
        public User GetUser(string cardNo)
        {
            User user = rep.Get(wt => (wt.cardNo == cardNo || wt.userId == cardNo));
            return user;
        }

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="days">工号</param>
        /// <returns></returns>
        public User GetNameid(string userId)
        {
            User userName = rep.Get(wt => (wt.userId == userId));
            return userName;
        }
        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="days">名称</param>
        /// <returns></returns>
        public User GetID(string userName)
        {
            User cardNo = rep.Get(wt => (wt.userName == userName));
            return cardNo;
        }

        /// <summary>
        /// 查询人员名称接口
        /// </summary>
        /// <param name="code">卡号</param>
        /// <returns></returns>
        public string QueryUser(string code,int state) 
        {
            if (string.IsNullOrWhiteSpace(code))
                return "";
            User user = new User();
            try
            {
                if (state == 0)///根据卡号查
                {
                    user = GetUser(code);
                }
                if (user == null || string.IsNullOrEmpty(user.userName)) //BS端同步
                {
                    string url = GlobalData.CfgHelper.GetKeyValue("API_QueryUser");
                    var requestData = new
                    {
                        userIds = code,
                        isCardNo = 1
                    };
                    string json = HttpDataTrans.DataTrans(url, "", RequestType.POST, requestData);
                    List<User> userlst = JsonResult<List<User>>.ConvertToModel(json);
                    if (userlst == null || userlst.Count == 0)
                    {
                        json = HttpDataTrans.DataTrans(url, "", RequestType.POST, new
                        {
                            userIds = code,
                            isCardNo = 0
                        });
                        if (string.IsNullOrWhiteSpace(json))
                        {
                            GlobalData.Log.Error("拉取人员信息失败！");
                        }
                        else
                        {
                            userlst = JsonResult<List<User>>.ConvertToModel(json);
                        }
                    }
                    if (userlst.Count > 0)
                        user = userlst[0];
                    Add(user);
                }
            }
            catch { user = new User(); user.userName = ""; }
            return user.userName;
        }

        /// <summary>
        /// 查询人员工号
        /// </summary>
        /// <param name="str_name"></param>
        /// <returns></returns>
        public string QueryUserID(string str_name)
        {
            string JN_str = "";
            try
            {
                JN_str = GetID(str_name).userId;
            }

            catch
            {
                return JN_str;
            }

            return JN_str;

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="wt"></param>
        public void Update(User wt)
        {
            rep.Update(wt);
            UnitOfWorkWT.Commit();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wt"></param>
        public void Delete(User wt)
        {
            rep.Delete(wt);
            UnitOfWorkWT.Commit();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="wt"></param>
        public void Add(User wt)
        {
            rep.Add(wt);
            UnitOfWorkWT.Commit();
        }
    }
}
