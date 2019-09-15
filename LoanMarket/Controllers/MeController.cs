using LoanMarket.PublicClass;
using LoanMarket.PublicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{

    public class MeController : Controller
    {

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 个人中心 - 首页
        /// </summary>
        /// <returns></returns>
        [IsLogin]
        public ActionResult Index()
        {
            User userInfo = SessionTool.Get<User>("user");
            return View(userInfo.No);
        }

        /// <summary>
        /// 修改资料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [IsLogin]
        public ActionResult Edit(int userId)
        {
            return View(userId);
        }

        /// <summary>
        /// 升级会员
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        [IsLogin]
        public ActionResult BuyPeculiarUser(int userNo)
        {

            return View(userNo);
        }

        /// <summary>
        /// 绑定上级
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        [IsLogin]
        public ActionResult BindLeader(int userNo)
        {
            return View(userNo);

        }

        /// <summary>
        /// 在线客服
        /// </summary>
        /// <returns></returns>
        public ActionResult ZaixianKefu( )
        {
            return View();

        }


    }
}