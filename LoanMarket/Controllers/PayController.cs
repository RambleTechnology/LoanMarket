using Com.Alipay;
using log4net;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers
{
    public class PayController : Controller
    {
        ILog log = LogManager.GetLogger("log4net");


        /// <summary>
        /// 提交支付
        /// </summary>
        [HttpPost]
        public void SubmitAlipay()
        {
            log.Info("start-提交支付");
            string _subject = Request.Form["subject"];
            string _body = Request.Form["body"];
            string _total_fee = Request.Form["total_fee"];

            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = "http://www.jiaodai.online/Pay/AsyncNotify";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = "http://www.jiaodai.online/Pay/SyncNotify";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //卖家支付宝帐户
            string seller_email = "82911045@qq.com";
            //必填

            //商户订单号,商户网站订单系统中唯一订单号，必填
            string out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            //订单名称
            string subject = _subject;
            //必填

            //付款金额
            string total_fee = _total_fee;
            //必填

            //订单描述

            string body = _body;
            //商品展示地址
            string show_url = "http://www.jiaodai.online/";

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = Request.UserHostAddress.ToString();
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("seller_email", seller_email);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            log.Info("拼接的html为：" + sHtmlText);
            Response.Write(sHtmlText);
        }

        /// <summary>
        /// 异步回调
        /// </summary>
        public void AsyncNotify()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
                if (verifyResult)//验证成功
                {
                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号
                    string out_trade_no = Request.Form["out_trade_no"];

                    //支付宝交易号
                    string trade_no = Request.Form["trade_no"];

                    //交易状态
                    string trade_status = Request.Form["trade_status"];

                    //TRADE_FINISHED:交易结束，不可退款
                    if (Request.Form["trade_status"] == "TRADE_FINISHED")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //该种交易状态只在两种情况下出现
                        //1、开通了普通即时到账，买家付款成功后。
                        //2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。
                    }
                    else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        //TRADE_SUCCESS：交易支付成功

                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。
                    }
                    else
                    {
                    }
                    log.Info("异步回调，成功");
                }
                else
                {
                    log.Info("异步回调，验证请求失败");
                }
            }
            else
            {
                log.Info("异步回调，参数为空");
            }
        }


        /// <summary>
        /// 同步回调
        /// </summary>
        public void SyncNotify()
        {
            var model = new AlipayReturnViewModel();
            SortedDictionary<string, string> sPara = GetRequestGet();
            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);
                if (verifyResult)//验证成功
                {
                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表

                    //商户订单号
                    model.out_trade_no = Request.QueryString["out_trade_no"];

                    //支付宝交易号
                    model.trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    model.trade_status = Request.QueryString["trade_status"];
                    if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                        model.message = "支付成功";
                        log.Info("同步回调，支付成功");
                    }
                    else
                    {
                        model.message = "支付失败";
                        log.Info("同步回调，支付失败");
                    }
                }
                else
                {
                    log.Info("同步回调，请求验证失败");
                }
            }
            else
            {
                log.Info("同步回调，参数为空");
            }
        }

        /// <summary>
        /// 组织请求参数
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }
            return sArray;
        }


        /// <summary>
        /// 组织请求参数
        /// </summary>
        /// <returns></returns>

        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }



        //        枚举名称 枚举说明
        //WAIT_BUYER_PAY 交易创建，等待买家付款
        //TRADE_CLOSED    未付款交易超时关闭，或支付完成后全额退款
        //TRADE_SUCCESS   交易支付成功
        //TRADE_FINISHED  交易结束，不可退款




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