using LoanMarket.PublicClass;
using LoanMarket.PublicClass;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    public class LoanController : Controller
    {



        public ActionResult Index()
        {
            return View();
        }


        public string test()
        {
            QrCode.CreateQrCode("");
            return "";
        }


    }
}