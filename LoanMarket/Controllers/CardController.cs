﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{
    /// <summary>
    /// 信用卡
    /// </summary>
    /// <returns></returns>
    public class CardController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YangkaTiejiqiao()
        {
            return View();
        }


        /// <summary>
        /// 申卡技巧
        /// </summary>
        /// <returns></returns>
        public ActionResult ShenkaJiqiao()
        {
            return View();
        }

    }
}