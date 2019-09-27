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
    }
}