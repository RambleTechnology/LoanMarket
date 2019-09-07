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

        public ActionResult List(int typeId)
        {
            return View(typeId);
        }

        public ActionResult DaPiPei()
        {
            return View();
        }
        public ActionResult XiaoePiPei()
        {
            return View();
        }

        public ActionResult Card()
        {
            return View();
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
        /// 产品列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public ActionResult ProductList(int typeId)
        {
            return View(typeId);
        }

        /// <summary>
        /// 白条花呗
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public ActionResult BaitiaoHuabei()
        {
            return View();
        }


    }
}