using Newtonsoft.Json;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Com.Alipay;
using LoanMarket.AliPay;
using log4net;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aop.Api.Util;

namespace LoanMarket.Controllers
{
    public class PayController : Controller
    {
        ILog log = LogManager.GetLogger("log4net");

        /// <summary>
        /// 测试在线支付
        /// </summary>
        public void TestPayment()
        {
            string _subject = Request.Form["subject"];
            string _body = Request.Form["body"];
            string _total_fee = Request.Form["total_fee"];
            log.Info("入参subject" + _subject);
            log.Info("入参body" + _body);
            log.Info("入参total_fee" + _total_fee);

        }


        /// <summary>
        /// 购买会员
        /// </summary>
        public void UpgradePeculiarUser()
        {
            log.Info("start购买会员");
            string orderNo = "UpgradePeculiarUser" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            log.Info("购买会员，orderNo:" + orderNo);
            SubmitPayment(orderNo, "购买会员", "98", "描述信息，重置会员");
        }



        /// <summary>
        /// 提交支付 - 新版本手机网站支付
        /// </summary>
        public void SubmitPayment(string orderNo, string orderName, string amount, string describe)
        {
            log.Info("start-提交支付");
            DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);
            // 外部订单号，商户网站订单系统中唯一的订单号
            string out_trade_no = orderNo;
            // 订单名称
            string subject = orderName;
            // 付款金额
            string total_amout = amount;
            // 商品描述
            string body = describe;
            // 支付中途退出返回商户网站地址
            string quit_url = "http://www.jiaodai.online/Pay/PayBreakOff";
            // 组装业务参数model
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = total_amout;
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "QUICK_WAP_WAY";
            model.QuitUrl = quit_url;
            log.Info("请求阿里，业务model：" + JsonConvert.SerializeObject(model));
            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            // 设置支付完成同步回调地址
            request.SetReturnUrl("http://www.jiaodai.online/Pay/SyncNotify");
            // 设置支付完成异步通知接收地址
            request.SetNotifyUrl("http://www.jiaodai.online/Pay/AsyncNotify");
            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradeWapPayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                log.Info("阿里响应信息：" + response.Body);
                Response.Write(response.Body);
            }
            catch (Exception e)
            {
                log.Info("支付异常，异常信息为：" + e.Message);
            }
        }

        /// <summary>
        /// 异步回调
        /// </summary>
        public void AsyncNotify()
        {
            Dictionary<string, string> sArray = GetRequestPost();
            if (sArray.Count != 0)
            {
                bool flag = AlipaySignature.RSACheckV1(sArray, config.alipay_public_key, config.charset, config.sign_type, false);
                if (flag)
                {
                    //交易状态
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //请务必判断请求时的total_amount与通知时获取的total_fee为一致的
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                    string trade_status = Request.Form["trade_status"];
                    log.Info("异步回调,trade_status为：" + trade_status);
                    log.Info("异步回调，成功");
                    Response.Write("success");
                }
                else
                {
                    log.Info("异步回调，失败");
                    Response.Write("fail");
                }
            }
            else
            {
                log.Info("异步回调，获取到的参数为空");
            }
        }


        /// <summary>
        /// 同步回调
        /// </summary>
        public void SyncNotify()
        {
            Dictionary<string, string> sArray = GetRequestGet();
            if (sArray.Count != 0)
            {
                bool flag = AlipaySignature.RSACheckV1(sArray, config.alipay_public_key, config.charset, config.sign_type, false);
                if (flag)
                {
                    Response.Write("同步验证通过");
                    log.Info("同步回调，验证通过");
                }
                else
                {
                    Response.Write("同步验证失败");
                    log.Info("同步回调，验证失败");
                }
            }
            else
            {
                log.Info("同步回调，获取到的参数为空");
            }
        }



        /// <summary>
        /// 异步回调 - 参数处理
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetRequestPost()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //coll = Request.Form;
            coll = Request.Form;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;

        }


        /// <summary>
        /// 同步回调 - 参数处理
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetRequestGet()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //coll = Request.Form;
            coll = Request.QueryString;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }
            return sArray;

        }


        /// <summary>
        /// 中断支付
        /// </summary>
        /// <returns></returns>
        public ActionResult PayBreakOff()
        {
            return View();
        }




    }

    public class AlipayReturnViewModel
    {
        //商户订单号
        public string out_trade_no { get; set; }
        //支付宝交易号
        public string trade_no { get; set; }
        //交易状态
        public string trade_status { get; set; }
        public string message { get; set; }
    }
}