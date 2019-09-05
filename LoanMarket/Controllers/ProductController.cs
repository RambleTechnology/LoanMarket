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
        public ActionResult XiaoPiPei()
        {
            return View();
        }
        public ActionResult HotProduct()
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
       
 
    }
}