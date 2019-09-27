/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： WithdrawBLL
* 版本号： V1.0.0.0
* 唯一标识： ff614be2-dc63-4756-bbf3-68e35fa0e75f
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/27 15:17:04

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/27 15:17:04
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    /// <summary>
    /// 提现密码-BLL
    /// </summary>
    public class WithdrawApplyBLL : BaseBLL
    {
        /// <summary>
        /// 创建提现申请
        /// </summary>
        /// <returns></returns>
        public int Create(WithdrawApplyApiModel applyModel)
        {
            if (applyModel == null)
            {
                return 0;
            }
            if (applyModel.UserNo <= 0)
            {
                return 0;
            }
            LoanMarketWithdrawApply model = new LoanMarketWithdrawApply();
            model.Id = GuidTool.GenerateKey();
            model.Amount = applyModel.Amount;
            model.ApplyWithwrawAmount = applyModel.ApplyWithwrawAmount;
            model.CreateTime = DateTime.Now;
            model.Status = "提交申请";
            model.UpdateTime = DateTime.Now;
            model.UserNo = applyModel.UserNo;
            UserBLL userBLL = new UserBLL();
            UserApiModel userInfo = userBLL.GetUserInfo(applyModel.UserNo);
            model.UserNickName = userInfo.NickName;
            model.UserRealName = userInfo.RealName;
            model.ZFBAccount = applyModel.ZFBAccount;
            int res = withdrawApply.Create(model);
            UserApiModel updateUserWithdrawAmount = new UserApiModel()
            {
                No = applyModel.UserNo,
                WithdrawAmount = applyModel.Amount - applyModel.ApplyWithwrawAmount
            };
            if (userBLL.UpdateWithdrawAmount(updateUserWithdrawAmount) > 0)
            {
                return res;
            }
            else
            {
                return 0;
            }
        }
    }
}