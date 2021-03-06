﻿using System;
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
        /// 新手指南
        /// </summary>
        /// <returns></returns>
        public ActionResult XinshouZhinan()
        {
            return View();
        }


        /// <summary>
        /// 最新扣子
        /// </summary>
        /// <returns></returns>
        public ActionResult ZuixinKouzi()
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


        /// <summary>
        /// 申卡技巧
        /// </summary>
        /// <returns></returns>
        public ActionResult ShenkaJiqiao()
        {
            return View();
        }



        /// <summary>
        /// 每日黑科技
        /// </summary>
        /// <returns></returns>
        public ActionResult HeiKeji()
        {
            return View();
        }

        /// <summary>
        /// 滚动新闻
        /// </summary>
        /// <returns></returns>

        public ActionResult NewsDetails(int no)
        {
            return View(no);
        }

        /// <summary>
        /// 黑科技详情
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public ActionResult HeikejiDetail(int no)
        {
            return View(no);
        }

        /// <summary>
        /// 财经模块   搜索
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult SearchCaijing(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }

    }
}