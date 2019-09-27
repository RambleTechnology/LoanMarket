using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using LoanMarket.BLL;
using LoanMarket.BLL.ApiModel;
using LoanMarket.PublicClass;
using LoanMarket.PublicModels;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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
        /// 通过验证码登录
        /// </summary>
        /// <returns></returns>
        public ActionResult SmsLogin()
        {
            log.Info("用户登录-通过短信验证码");
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
        [IsLogin]
        public ActionResult ZaixianKefu()
        {
            return View();

        }



        /// <summary>
        /// 提现密码
        /// </summary>
        /// <returns></returns>
        [IsLogin]
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
            ViewBag.SpreadUrl = spreadUrl;
            return View();
        }

        /// <summary>
        /// 下载 app      
        /// </summary>
        /// <returns></returns>
        [IsLogin]
        public ActionResult DownloadApp()
        {
            return View();
        }

        /// <summary>
        /// 下载安卓安装包
        /// </summary>
        /// <returns></returns>
        [IsLogin]
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
        [IsLogin]
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

        /// <summary>
        /// 我的分享
        /// </summary>
        /// <returns></returns>
        [IsLogin]
        public ActionResult MyShare()
        {
            User userInfo = SessionTool.Get<User>("user");
            SpreadBLL bll = new SpreadBLL();
            var model = bll.FindSpreadUser((int)userInfo.No);
            List<SpreadUserApiModel> teamSpread = new List<SpreadUserApiModel>();
            List<SpreadUserApiModel> spreadUserApiModels = bll.FindSpreadUser((int)userInfo.No);
            foreach (var item in spreadUserApiModels)
            {
                List<SpreadUserApiModel> temp = bll.FindSpreadUser(item.ToUserNo);
                teamSpread = teamSpread.Concat(temp).ToList();
            }
            teamSpread = teamSpread.Concat(bll.FindSpreadUser((int)userInfo.No)).ToList();
            ViewBag.TeamSpread = teamSpread;
            return View(model);
        }


        /// <summary>
        /// 生成一个验证码
        /// </summary>
        /// <returns></returns>        
        public FileResult CreateVerifyCode()
        {
            VerifyCode vc = new VerifyCode();
            byte[] result = vc.GetVerifyCode();
            return File(result, "image/jpg");
        }



        /// <summary>
        /// 发送手机验证码 - 注册
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="verifyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SendSms(string mobile, string verifyCode)
        {
            JsonResult json = new JsonResult();
            if (string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(verifyCode))
            {
                json.Data = new { Code = "NO", Message = "手机号和图形验证码不可为空。" };
                return json;
            }
            string verify = SessionTool.Get<string>("verifyCode");
            log.Info("Session中的图形验证码为：" + verify);
            if (verify != verifyCode)
            {
                json.Data = new { Code = "NO", Message = "图形验证码错误。" };
                return json;
            }
            //01生成随机码
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int iResult;
            int iUp = 99999;
            int iDown = 10000;
            iResult = ran.Next(iDown, iUp);
            string code = "8" + iResult.ToString();
            log.Info("手机验证码为：" + code);
            SessionTool.Set("SmsCode", code);
            //02 调用阿里云短信接口
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAI4Fe7cxYGwM7MfJ2WHBuM", "EcwdmQTE3SlTgnRPU8EiCDv9LC5Rku");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            request.AddQueryParameters("PhoneNumbers", mobile);
            request.AddQueryParameters("SignName", "鑫汇");
            request.AddQueryParameters("TemplateCode", "SMS_174650238");
            request.AddQueryParameters("TemplateParam", "{\"code\":\"" + code + "\"}");
            try
            {
                log.Info("发送短信，请求报文：" + JsonConvert.SerializeObject(request));
                CommonResponse response = client.GetCommonResponse(request);
                log.Info("发送短信，response：" + JsonConvert.SerializeObject(response.Data));
                SmsResponseModel model = JsonConvert.DeserializeObject<SmsResponseModel>(response.Data);
                if (model.Code == "OK")
                {
                    json.Data = new { Code = "OK", Message = "验证码发送成功。" };
                }
                else
                {
                    json.Data = new { Code = "NO", Message = "验证码发送失败。" };
                }
            }
            catch (Aliyun.Acs.Core.Exceptions.ServerException e)
            {
                log.Info("发送短信报异常，ServerException:" + JsonConvert.SerializeObject(e));
                json.Data = new { Code = "NO", Message = "验证码发送失败，ServerException异常。" };
            }
            catch (ClientException e)
            {
                log.Info("发送短信报异常，ClientException:" + JsonConvert.SerializeObject(e));
                json.Data = new { Code = "NO", Message = "验证码发送失败，ClientException异常。" };
            }
            return json;
        }


        /// <summary>
        /// 发送手机验证码 - 修改提现密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="verifyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SendWithdrawSms(string mobile, string verifyCode)
        {
            JsonResult json = new JsonResult();
            if (string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(verifyCode))
            {
                json.Data = new { Code = "NO", Message = "手机号和图形验证码不可为空。" };
                return json;
            }
            string verify = SessionTool.Get<string>("verifyCode");
            log.Info("修改提现密码,Session中的图形验证码为：" + verify);
            if (verify != verifyCode)
            {
                json.Data = new { Code = "NO", Message = "图形验证码错误。" };
                return json;
            }
            //01生成随机码
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int iResult;
            int iUp = 99999;
            int iDown = 10000;
            iResult = ran.Next(iDown, iUp);
            string code = "8" + iResult.ToString();
            log.Info("修改提现密码,手机验证码为：" + code);
            SessionTool.Set("SmsCode", code);
            //02 调用阿里云短信接口
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAI4Fe7cxYGwM7MfJ2WHBuM", "EcwdmQTE3SlTgnRPU8EiCDv9LC5Rku");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            request.AddQueryParameters("PhoneNumbers", mobile);
            request.AddQueryParameters("SignName", "鑫汇");
            request.AddQueryParameters("TemplateCode", "SMS_174651230");
            request.AddQueryParameters("TemplateParam", "{\"code\":\"" + code + "\"}");
            try
            {
                log.Info("修改提现密码,发送短信，请求报文：" + JsonConvert.SerializeObject(request));
                CommonResponse response = client.GetCommonResponse(request);
                log.Info("修改提现密码,发送短信，response：" + JsonConvert.SerializeObject(response.Data));
                SmsResponseModel model = JsonConvert.DeserializeObject<SmsResponseModel>(response.Data);
                if (model.Code == "OK")
                {
                    json.Data = new { Code = "OK", Message = "验证码发送成功。" };
                }
                else
                {
                    json.Data = new { Code = "NO", Message = "验证码发送失败。" };
                }
            }
            catch (Aliyun.Acs.Core.Exceptions.ServerException e)
            {
                log.Info("修改提现密码,发送短信报异常，ServerException:" + JsonConvert.SerializeObject(e));
                json.Data = new { Code = "NO", Message = "验证码发送失败，ServerException异常。" };
            }
            catch (ClientException e)
            {
                log.Info("修改提现密码,发送短信报异常，ClientException:" + JsonConvert.SerializeObject(e));
                json.Data = new { Code = "NO", Message = "验证码发送失败，ClientException异常。" };
            }
            return json;
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <returns></returns>        
        [IsLogin]
        public ActionResult Withdraw()
        {
            User userInfo = SessionTool.Get<User>("user");
            ViewBag.UserNo = userInfo.No;
            return View();
        }


    }
}