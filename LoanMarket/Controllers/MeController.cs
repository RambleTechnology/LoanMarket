using LoanMarket.PublicClass;
using LoanMarket.PublicModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{

    public class MeController : Controller
    {
        ILog log = LogManager.GetLogger("log4net");

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            log.Info("用户登录");
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
        public ActionResult ZaixianKefu()
        {
            return View();

        }



        /// <summary>
        /// 提现密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Cashpsd()
        {
            return View();
        }

        /// <summary>
        /// 分享赚钱
        /// </summary>
        /// <returns></returns>
        [IsLogin]
        public ActionResult Sharemoney()
        {
            User userInfo = SessionTool.Get<User>("user");
            string spreadUrl = "http://www.jiaodai.online/Me/SpreadRegister?fromUserNo=" + userInfo.No;
            string spreadQrCodeUrl = QrCode.CreateSpreadQrCode(spreadUrl, userInfo.NickName);
            ViewBag.SpreadQrCodeUrl = spreadQrCodeUrl;
            return View();
        }

        /// <summary>
        /// 下载 app      
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadApp()
        {
            return View();
        }

        /// <summary>
        /// 下载安卓安装包
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadAndroid()
        {
            string rootPath = Server.MapPath("~");
            string path = rootPath + "DowmloadApp/loanmarket.apk";
            return File(path, "application/octet-stream", "loanmarket.apk");
        }


        /// <summary>
        /// 下载ios安装包
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadIos()
        {
            string rootPath = Server.MapPath("~");
            string path = rootPath + "DowmloadApp/loanmarket.ipa";
            return File(path, "application/octet-stream", "loanmarket.ipa");
        }

        /// <summary>
        /// 推广注册
        /// </summary>
        /// <param name="fromUserNo"></param>
        /// <returns></returns>
        public ActionResult SpreadRegister(int fromUserNo)
        {
            return View(fromUserNo);
        }



    }
}