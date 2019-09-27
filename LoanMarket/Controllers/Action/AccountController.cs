using LoanMarket.BLL;
using LoanMarket.BLL.ApiModel;
using LoanMarket.Controllers.Action.Param;
using LoanMarket.PublicClass;
using LoanMarket.PublicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers.Action
{
    public class AccountController : BaseActionController
    {

        /// <summary>
        /// 短信验证码登录
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="smscode"></param>
        /// <returns></returns>
        public string SmsLogin(string Mobile, string smscode)
        {
            if (string.IsNullOrEmpty(Mobile) || string.IsNullOrEmpty(smscode))
            {
                return "手机号和验证码不可为空";
            }
            if (SessionTool.Get<string>("SmsCode") != smscode)
            {
                return "短信验证码错误";
            }
            User userInfo = user.GetUserInfoByMobile(Mobile);
            if (userInfo != null && userInfo.No > 0)
            {
                SessionTool.Set("user", userInfo);
                return "登录成功";
            }
            else
            {
                return "用户不存在或手机号和密码不匹配";
            }
        }


        /// <summary>
        /// 保存提现密码
        /// </summary>        
        /// <param name="password"></param>
        /// <returns></returns>
        [IsLogin]
        [HttpPost]
        public string SaveWithdrawPassword(string userpwd, string Password)
        {
            if (string.IsNullOrEmpty(userpwd) || string.IsNullOrEmpty(Password))
            {
                return "密码不可为空";
            }
            if (userpwd != Password)
            {
                return "两次输入的密码不一致";
            }
            User userInfo = SessionTool.Get<User>("user");
            if (withdraw.Save((int)userInfo.No, Password) > 0)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        /// <summary>
        /// 创建提现申请
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [IsLogin]
        [HttpPost]
        public string CreateWithdrawApply(CreateWithdrawApplyParam param)
        {
            if (ModelState.IsValid)
            {
                User userInfo = SessionTool.Get<User>("user");
                string withdrawPassword = withdraw.GetWithdrawPassword((int)userInfo.No);
                if (param.WithdrawPassword != withdrawPassword)
                {
                    return "提现密码错误";
                }
                UserBLL userBLL = new UserBLL();
                UserApiModel userApiModel1 = userBLL.GetUserInfo(Convert.ToInt32((int)userInfo.No));                
                decimal allowWithdrawAmount = userApiModel1.WithdrawAmount;
                if (param.ApplyWithwrawAmount <= allowWithdrawAmount)
                {
                    WithdrawApplyApiModel model = new WithdrawApplyApiModel()
                    {
                        Amount = allowWithdrawAmount,
                        ApplyWithwrawAmount = param.ApplyWithwrawAmount,
                        UserNo = (int)userInfo.No,
                        ZFBAccount = param.ZFBAccount,
                        SpareField1 = param.SpareField1
                    };
                    if (withdrawApply.Create(model) > 0)
                    {
                        return "成功";
                    }
                    else
                    {
                        return "失败";
                    }
                }
                else
                {
                    return "提现金额不可大于总金额，总金额为：" + allowWithdrawAmount;
                }
            }
            else
            {
                return "提现金额、提现密码和支付宝账号不可为空";
            }

        }

    }
}