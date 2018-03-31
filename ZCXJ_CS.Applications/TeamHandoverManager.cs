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
    public class TeamHandoverManager
    {
        public UnitOfWork UnitOfWorkWT = null;
        public DbContext context = new SQLiteContext();
        RepositoryBase<TeamHandover> rep = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TeamHandoverManager()
        {
            UnitOfWorkWT = new UnitOfWork(context);
            rep = new RepositoryBase<TeamHandover>(UnitOfWorkWT);
        }

        /// <summary>
        /// 查询几天前的交接班记录
        /// </summary>
        /// <param name="days">天数</param>
        /// <returns></returns>
        public List<TeamHandover> GetList(int days)
        {
            DateTime time = DateTime.Now.AddDays(days);
            List<TeamHandover> Thlist = rep.GetList(wt => (wt.receiveTime > time)).ToList<TeamHandover>();
            return Thlist;
        }
        /// <summary>
        /// 获取用于显示的交接班记录列表
        /// </summary>
        /// <param name="days">时间限制，例如14表示14天内的记录</param>
        /// <returns></returns>
        public List<TeamHandoverView> GetTeamHandoverRecords(int days = 14)
        {
            return GetList(-days).OrderByDescending(t => t.receiveTime).Select(v => new TeamHandoverView
            {
                receiveTime = GlobalData.Utils.DateTimeToZh(v.receiveTime),
                receiveLeaderName = v.receiveLeaderName,
                remark = v.Remark,
                receivePersonsName = v.receivePersonsName,
                handLeaderName = v.handLeaderName,
                handoverTime = GlobalData.Utils.DateTimeToZh(v.handoverTime),
                handPersonsName = v.handPersonsName,
                describe = v.describe
            }).ToList();
        }
        /// <summary>
        /// 班产清零
        /// </summary>
        public void CleanCount()
        {
            #region 班产清零

            GlobalData.Scada.WriteData("MES_Clean", 1);

            #endregion
        }

        /// <summary>
        /// 上传交接班记录
        /// </summary>
        public void DoQuery()
        {
            #region 上传交接班信息至BS端

            try
            {
                TeamHandover model = new TeamHandover();
                List<TeamHandover> list = new List<TeamHandover>();
                int listlenth;
                list = GetList(-7);
                listlenth = list.Count;
                model = list[listlenth - 1];

                string url = GlobalData.CfgHelper.GetKeyValue("API_UpTeamHandover");
                var requestData = new
                {
                    machineNo = model.machineNo,
                    handoverTime = model.handoverTime,
                    handTeamLeader = model.handTeamLeader,
                    handTeamNo = model.handTeamNo,
                    handPersons = model.handPersons,
                    handShift = model.handShift,
                    receiveTeamLeader = model.receiveTeamLeader,
                    receiveTeamNo = model.receiveTeamNo,
                    receiveShift = model.receiveShift,
                    receivePersons = model.receivePersons,
                    describe = model.describe
                };
                string json = HttpDataTrans.DataTrans(url, "", RequestType.POST, requestData);
                if (string.IsNullOrWhiteSpace(json))
                {
                    GlobalData.Log.Error("上传交接班数据失败！");
                    //MessageBox.Show("上传交接班数据失败，请联系管理员！");
                }

            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        /// <summary>
        /// 更新全局用户对象
        /// </summary>
        public void UpdateCurUser(string receiveid, string receivename)
        {
            GlobalData.CurUser.Clear();
            GlobalData.CurUser.userId = receiveid;
            GlobalData.CurUser.userName = receivename;
        }

        /// <summary>
        /// 班组人员工号写入配置文件
        /// </summary>
        /// <param name="str_hand"></param>
        public void Remove(string[] str_hand)
        {
            try
            {
                string id = "";
                foreach (string item in str_hand)
                {
                    id = id + item + ",";
                }
                if (id != "")
                {
                    GlobalData.CfgHelper.SaveKeyValue("工号", id.Substring(0, id.Length - 1));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 插入交接班记录(交班按钮控制)
        /// </summary>
        /// <param name="State">交接班状态</param>
        /// <param name="str_receive">接班工号</param>
        /// <param name="str_receivename">接班名称</param>
        /// <param name="cobshifttext">班组名称</param>
        /// <param name="str_hand">交班工号</param>
        /// <param name="str_handname">交班名称</param>
        /// <param name="textboxshift">交班人</param>
        /// <param name="cobpasstext">交班记录</param>
        public void HandReceive(int State, string[] str_receive, string[] str_receivename, string cobshifttext, string[] str_hand, string[] str_handname, string textboxshift, string cobpasstext)
        {
            string  MachineNo = GlobalData.MachineId;
            UserManager UsManager = new UserManager();

            #region 插入交接班记录
            try
            {
                switch (State)
                {
                    case 0://接班记录

                        string id = "";
                        string name = "";
                        foreach (string item in str_receive)
                        {
                            id = id + item + ",";
                        }
                        foreach (string item in str_receivename)
                        {
                            name = name + item + ",";
                        }
                        TeamHandover model = new TeamHandover();
                        model.handoverTime = DateTime.Now;
                        model.receiveTime = DateTime.Now;
                        model.planHandoverTime = DateTime.Now;
                        model.planReceiveTime = DateTime.Now;
                        model.receiveTeamLeader = str_receive[0];
                        model.receiveLeaderName = str_receivename[0];
                        model.receivePersons = id.Substring(0, id.Length - 1);
                        model.receivePersonsName = name.Substring(0, name.Length - 1);
                        model.machineNo = MachineNo;
                        switch (cobshifttext)
                        {
                            case "甲班":
                                model.handTeamNo = "001";
                                model.receiveTeamNo = "001";
                                break;
                            case "乙班":
                                model.handTeamNo = "002";
                                model.receiveTeamNo = "002";
                                break;
                            case "丙班":
                                model.handTeamNo = "003";
                                model.receiveTeamNo = "003";
                                break;
                            case "丁班":
                                model.handTeamNo = "004";
                                model.receiveTeamNo = "004";
                                break;
                            default:
                                break;
                        }
                        model.handShift = cobshifttext;
                        model.receiveShift = cobshifttext;

                        //model.shiftId = model.receiveTeamLeader;
                        Add(model);
                        break;

                    case 1://更新交班记录同时插入下个班接班记录
                        //ComboBox comBox = (ComboBox)panel_pass.Controls.Find("cobcontent", true)[0];
                        string receiveID = "";
                        string receiveName = "";
                        string handID = "";
                        string handName = "";

                        foreach (string item in str_hand)
                        {
                            handID = handID + item + ",";
                        }
                        foreach (string item in str_handname)
                        {
                            handName = handName + item + ",";
                        }
                        List<TeamHandover> list_hand = new List<TeamHandover>();
                        TeamHandoverManager um_hand = new TeamHandoverManager();
                        int listlenth;
                        list_hand = um_hand.GetList(-7);
                        listlenth = list_hand.Count;
                        list_hand[listlenth - 1].handoverTime = DateTime.Now;
                        list_hand[listlenth - 1].planHandoverTime = DateTime.Now;
                        list_hand[listlenth - 1].handTeamLeader = UsManager.QueryUserID(textboxshift);
                        list_hand[listlenth - 1].handPersons = handID.Substring(0, handID.Length - 1);
                        list_hand[listlenth - 1].describe = cobpasstext;
                        list_hand[listlenth - 1].handLeaderName = textboxshift;
                        list_hand[listlenth - 1].handPersonsName = handName.Substring(0, handName.Length - 1);
                        um_hand.Update(list_hand[listlenth - 1]);

                        um_hand.CleanCount();
                        um_hand.DoQuery();

                        foreach (string item in str_receive)
                        {
                            receiveID = receiveID + item + ",";
                        }
                        foreach (string item in str_receivename)
                        {
                            receiveName = receiveName + item + ",";
                        }
                        TeamHandover model_receive = new TeamHandover();
                        model_receive.handoverTime = DateTime.Now;
                        model_receive.receiveTime = DateTime.Now;
                        model_receive.planHandoverTime = DateTime.Now;
                        model_receive.planReceiveTime = DateTime.Now;
                        //model_receive.shiftId = (int.Parse(list_hand[listlenth - 1].shiftId) + 1).ToString();
                        model_receive.receiveTeamLeader = str_receive[0];
                        model_receive.receiveLeaderName = str_receivename[0];
                        model_receive.receivePersons = receiveID.Substring(0, receiveID.Length - 1);
                        model_receive.receivePersonsName = receiveName.Substring(0, receiveName.Length - 1);
                        model_receive.machineNo = MachineNo;

                        switch (cobshifttext)
                        {
                            case "甲班":
                                model_receive.handTeamNo = "001";
                                model_receive.receiveTeamNo = "001";
                                break;
                            case "乙班":
                                model_receive.handTeamNo = "002";
                                model_receive.receiveTeamNo = "002";
                                break;
                            case "丙班":
                                model_receive.handTeamNo = "003";
                                model_receive.receiveTeamNo = "003";
                                break;
                            case "丁班":
                                model_receive.handTeamNo = "004";
                                model_receive.receiveTeamNo = "004";
                                break;
                            default:
                                break;
                        }
                        model_receive.handShift = cobshifttext;
                        model_receive.receiveShift = cobshifttext;
                        Add(model_receive);
                        //更新全局用户对象
                        UpdateCurUser(str_receive[0], str_receivename[0]);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                GlobalData.Log.Info("", ex);
            }

            #endregion
        }

        /// <summary>
        /// 插入交接班记录
        /// </summary>
        /// <param name="State">交接班状态</param>
        /// <param name="str_receive">接班工号</param>
        /// <param name="str_receivename">接班名称</param>
        /// <param name="textboxobtain">接班人</param>
        /// <param name="cobshifttext">班组名称</param>
        /// <param name="cobreceivetext">接班记录</param>
        /// <param name="str_hand">交班工号</param>
        /// <param name="str_handname">交班名称</param>
        /// <param name="textboxshift">交班人</param>
        /// <param name="cobpasstext">交班记录</param>
        public void HandReceiveOther(int State, string[] str_receive, string[] str_receivename,string textboxobtain, string cobshifttext,string cobreceivetext, string[] str_hand, string[] str_handname, string textboxshift, string cobpasstext)
        {
            string MachineNo = GlobalData.MachineId;
            UserManager UsManager = new UserManager();

            #region 插入交接班记录
            try
            {
                switch (State)
                {
                    case 0://接班记录

                        string id = "";
                        string name = "";
                        foreach (string item in str_receive)
                        {
                            id = id + item + ",";
                        }
                        foreach (string item in str_receivename)
                        {
                            name = name + item + ",";
                        }

                        List<TeamHandover> list = new List<TeamHandover>();
                        int lenth;
                        list = GetList(-7);
                        lenth = list.Count;

                        TeamHandover model = new TeamHandover();
                        model.handoverTime = DateTime.Now;
                        model.receiveTime = DateTime.Now;
                        model.planHandoverTime = DateTime.Now;
                        model.planReceiveTime = DateTime.Now;
                        model.receiveTeamLeader = UsManager.QueryUserID(textboxobtain);
                        model.receivePersons = id.Substring(0, id.Length - 1);
                        model.receiveLeaderName = textboxobtain;
                        model.receivePersonsName = name.Substring(0, name.Length - 1);
                        //if (lenth == 0)
                        //{
                        //    model.shiftId = "1";
                        //}
                        //else
                        //{
                        //    model.shiftId = (int.Parse(list[lenth - 1].shiftId) + 1).ToString();
                        //}

                        switch (cobshifttext)
                        {
                            case "甲班":
                                model.handTeamNo = "001";
                                model.receiveTeamNo = "001";
                                break;
                            case "乙班":
                                model.handTeamNo = "002";
                                model.receiveTeamNo = "002";
                                break;
                            case "丙班":
                                model.handTeamNo = "003";
                                model.receiveTeamNo = "003";
                                break;
                            case "丁班":
                                model.handTeamNo = "004";
                                model.receiveTeamNo = "004";
                                break;
                            default:
                                break;
                        }
                        model.handShift = cobshifttext;
                        model.receiveShift = cobshifttext;

                        model.Remark = cobreceivetext;
                        model.machineNo = MachineNo;
                        Add(model);
                        //更新全局用户对象
                        UpdateCurUser(str_receive[0], str_receivename[0]);
                        break;

                    case 1://更新交班记录
                        //ComboBox comBox = (ComboBox)panel_pass.Controls.Find("cobcontent", true)[0];
                        string handID = "";
                        string handName = "";
                        foreach (string item in str_hand)
                        {
                            handID = handID + item + ",";
                        }
                        foreach (string item in str_handname)
                        {
                            handName = handName + item + ",";
                        }
                        List<TeamHandover> list_hand = new List<TeamHandover>();
                        int listlenth;
                        list_hand = GetList(-7);
                        listlenth = list_hand.Count;
                        list_hand[listlenth - 1].handoverTime = DateTime.Now;
                        list_hand[listlenth - 1].planHandoverTime = DateTime.Now;
                        list_hand[listlenth - 1].handTeamLeader = UsManager.QueryUserID(textboxshift);
                        list_hand[listlenth - 1].handPersons = handID.Substring(0, handID.Length - 1);
                        list_hand[listlenth - 1].describe = cobpasstext;
                        list_hand[listlenth - 1].handLeaderName = textboxshift;
                        list_hand[listlenth - 1].handPersonsName = handName.Substring(0, handName.Length - 1);
                        Update(list_hand[listlenth - 1]);

                        CleanCount();
                        DoQuery();

                        break;

                    default:
                        break;
                }
            }

            catch (Exception ex)
            {
                GlobalData.Log.Info("", ex);
            }

            #endregion
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="wt"></param>
        public void Update(TeamHandover wt)
        {
            rep.Update(wt);
            UnitOfWorkWT.Commit();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wt"></param>
        public void Delete(TeamHandover wt)
        {
            rep.Delete(wt);
            UnitOfWorkWT.Commit();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="wt"></param>
        public void Add(TeamHandover wt)
        {
            rep.Add(wt);
            UnitOfWorkWT.Commit();
        }
    }
}
