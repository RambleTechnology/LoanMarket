using LoanMarket.BLL;
using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers.Action
{
    public class SpreadController : BaseActionController
    {

        /// <summary>
        /// 查找我的推广金额
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetMySpreadMoney(string no)
        {
            if (string.IsNullOrEmpty(no))
            {
                return "0";
            }
            UserBLL userBLL = new UserBLL();
            UserApiModel userInfo = userBLL.GetUserInfo(Convert.ToInt32(no));
            decimal amount = userInfo.WithdrawAmount;
            return Math.Round(amount, 2).ToString();
        }


    }
}