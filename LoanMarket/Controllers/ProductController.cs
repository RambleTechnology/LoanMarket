    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ProductList(int typeId)
        {
            return View(typeId);
        }

        public ActionResult List(int typeId)
        {
            return View(typeId);
        }

        /// <summary>
        /// 大额匹配
        /// </summary>
        /// <returns></returns>
        public ActionResult DaePipei()
        {
            return View();
        }


        /// <summary>
        /// 小额匹配
        /// </summary>
        /// <returns></returns>
        public ActionResult XiaoePipei()
        {
            return View();
        }

        /// <summary>
        /// 返佣产品
        /// </summary>
        /// <returns></returns>
        public ActionResult Fanyong()
        {
            return View();
        }

        /// <summary>
        /// 信用卡
        /// </summary>
        /// <returns></returns>
        public ActionResult XingyongKa()
        {
            return View();
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(string keyword)
        {
            return View();
        }

        /// <summary>
        /// 热门产品
        /// </summary>
        /// <returns></returns>
        public ActionResult HotProduct()
        {
            return View();
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int no)
        {
            return View(no);
        }

    }
}