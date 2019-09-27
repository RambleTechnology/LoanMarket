using LoanMarket.BLL;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers.Action
{
    public class BaseActionController : Controller
    {

        protected ILog log = LogManager.GetLogger("log4net");

        protected JsonResult json = new JsonResult();
        protected ForumBLL forum = new ForumBLL();
        protected SpreadBLL spread = new SpreadBLL();
        protected UserBLL user = new UserBLL();
        protected WithdrawBLL withdraw = new WithdrawBLL();
        protected WithdrawApplyBLL withdrawApply = new WithdrawApplyBLL();
    }
}