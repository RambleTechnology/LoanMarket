using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{
    [IsLogin]
    public class ForumController : Controller
    {

        /// <summary>
        /// 论坛
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            PublicModels.User u = SessionTool.Get<PublicModels.User>("user");
            return View();
        }

        /// <summary>
        /// 帖子详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int no)
        {
            return View(no);
        }

        /// <summary>
        /// 添加帖子
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 搜索帖子
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }



    }
}