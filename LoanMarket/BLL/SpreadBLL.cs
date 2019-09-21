/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： SpreadDLL
* 版本号： V1.0.0.0
* 唯一标识： e1438a7e-e8d2-4552-919a-38943c42c7ae
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/8/31 20:41:27

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/8/31 20:41:27
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using LoanMarket.PublicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class SpreadBLL : BaseBLL
    {

        BillBLL billBLL = new BillBLL();

        UserGroupBLL userGroup = new UserGroupBLL();


        /// <summary>
        /// 创建推广记录
        /// </summary>
        /// <param name="fromUserNo"></param>
        /// <param name="toUserNo"></param>
        /// <returns></returns>
        public int CreateSpread(int fromUserNo, int toUserNo)
        {
            spread.CreateSpread(new Models.LoanMarketSpread() { Id = GuidTool.GenerateKey(), FromUserNo = fromUserNo, ToUserNo = toUserNo, CreateTime = DateTime.Now, UpdateTime = DateTime.Now });
            try
            {
                //fromUser  是否是会员
                LoanMarketUser userInfo = user.GetUser(fromUserNo);
                if (userInfo.IsPeculiarUser == 1)
                {
                    #region 会员升级
                    //fromUset  所属组的升级条件
                    LoanMarketGroup group = userGroup.GetUserGroup(fromUserNo);
                    if (group != null)
                    {
                        //fromUser  已经推广人数
                        int alreadySpreadUserCount = GetSpreadCount(fromUserNo);
                        if (alreadySpreadUserCount >= Convert.ToInt32(group.UpCondition))
                        {
                            //fromUser  进行升级
                            userGroup.UpdateUserGroup(fromUserNo, (int)group.ParentNo);
                        }
                        else
                        {
                            log.Info("不满足升级条件。" + fromUserNo);
                        }
                    }
                    else
                    {
                        log.Info("创建推广记录SpreadBLL-CreateSpread：根据用户No查询不到所属组。" + fromUserNo);
                    }
                    #endregion
                    #region 创建推广返佣单
                    //推广人返佣30（直推）
                    BillApiModel fromUserBillModel = new BillApiModel()
                    {
                        Amount = 30,
                        FromUserNo = fromUserNo.ToString(),
                        ToUserNo = toUserNo.ToString(),
                        BillType = (int)BillTypeEnum.直推
                    };
                    string fromUserBillNo = billBLL.CreateBill(fromUserBillModel);
                    if (!string.IsNullOrEmpty(fromUserBillNo))
                    {
                        log.Info("推广返佣单，直推人返佣单创建成功。" + fromUserNo);
                    }
                    else
                    {
                        log.Info("推广返佣单，直推人返佣单创建失败。" + fromUserNo);
                    }
                    //推广人所属上级代理返佣
                    List<LoanMarketSpread> leaders = spread.FindUserLeaders(fromUserNo);
                    if (leaders != null && leaders.Count > 0)
                    {
                        foreach (LoanMarketSpread item in leaders)
                        {
                            //上级代理的用户编号
                            int leaderUserNo = item.FromUserNo;
                            //获取上级代理所属组
                            LoanMarketGroup leaderUserGroup = userGroup.GetUserGroup(leaderUserNo);
                            //获取上级代理应返佣金
                            decimal amount = GetSpreadAmountByUserGroupNo(leaderUserGroup.No);
                            BillApiModel leaderBillModel = new BillApiModel()
                            {
                                Amount = amount,
                                FromUserNo = leaderUserNo.ToString(),
                                ToUserNo = toUserNo.ToString(),
                                BillType = (int)BillTypeEnum.上级代理
                            };
                            string leaderBillNo = billBLL.CreateBill(leaderBillModel);
                            if (!string.IsNullOrEmpty(leaderBillNo))
                            {
                                log.Info("推广返佣单，上级代理返佣单创建成功。" + JsonConvert.SerializeObject(leaderBillModel));
                            }
                            else
                            {
                                log.Info("推广返佣单，上级代理返佣单创建失败。" + JsonConvert.SerializeObject(leaderBillModel));
                            }
                        }
                    }
                    else
                    {
                        log.Info("推广返佣金，推广人无上级代理." + fromUserNo);
                    }
                    #endregion
                }
                else
                {
                    //非会员，不会升级，也无推广费用
                    log.Info("创建推广记录SpreadBLL-CreateSpread：非会员，不会升级，也无推广费用." + fromUserNo);
                }
            }
            catch (Exception e)
            {
                log.Info("创建推广记录SpreadBLL-CreateSpread异常，异常信息为：" + e.Message + ".用户：" + fromUserNo);
            }
            return 1;
        }

        /// <summary>
        /// 查找已推广人数
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public int GetSpreadCount(int userNo)
        {
            return spread.GetSpreadCount(userNo);
        }


        /// <summary>
        /// 查询已推广的用户
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public List<SpreadUserApiModel> FindSpreadUser(int userNo)
        {
            List<LoanMarketSpread> list = spread.FindSpreadUser(userNo);
            List<SpreadUserApiModel> data = new List<SpreadUserApiModel>();
            if (list != null && list.Count > 0)
            {
                foreach (LoanMarketSpread item in list)
                {
                    SpreadUserApiModel spreadUserApiModel = new SpreadUserApiModel();
                    spreadUserApiModel.ToUserNo = item.ToUserNo;
                    spreadUserApiModel.CreateTime = (DateTime)item.CreateTime;
                    LoanMarketUser loanMarketUser = user.GetUser(item.ToUserNo);
                    spreadUserApiModel.Mobile = loanMarketUser.Mobile;
                    spreadUserApiModel.NickName = loanMarketUser.NickName;
                    spreadUserApiModel.IsPeculiarUser = loanMarketUser.IsPeculiarUser > 0 ? true : false;
                    LoanMarketGroup leaderUserGroup = userGroup.GetUserGroup(item.ToUserNo);
                    if (leaderUserGroup != null)
                    {
                        spreadUserApiModel.UserGroupName = leaderUserGroup.Name;
                    }
                    data.Add(spreadUserApiModel);
                }
            }
            return data;
        }

        /// <summary>
        /// 查找用户上级代理
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public List<LoanMarketSpread> FindUserLeaders(int userNo)
        {
            return spread.FindUserLeaders(userNo);
        }
    }
}