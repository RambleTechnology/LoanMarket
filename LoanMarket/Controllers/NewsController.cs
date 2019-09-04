using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{
    public class NewsController : Controller
    {
        /// <summary>
        /// 财经（新闻）
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 境外提额
        /// </summary>
        /// <returns></returns>
        public ActionResult JingwaiTie()
        {
            return View();
        }
    }
}