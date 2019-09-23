using LoanMarket.BLL;
using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// 升级会员
        /// </summary>        
        /// <returns></returns>
        public ActionResult UpdateVip()
        {
            return View();
        }
        /// <summary>
        /// 会员协议
        /// </summary>        
        /// <returns></returns>
        public ActionResult VipArgee()
        {
            return View();
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


        /// <summary>
        /// 最新口子
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public ActionResult ZuixinKouzi(int typeId)
        {
            return View(typeId);
        }

        /// <summary>
        /// 首页客服
        /// </summary>
        /// <returns></returns>
        public ActionResult Kefu()
        {
            return View();
        }

        /// <summary>
        /// 客服8
        /// </summary>
        /// <returns></returns>
        public ActionResult KefuEight()
        {
            return View();
        }

        /// <summary>
        /// 客服9
        /// </summary>
        /// <returns></returns>
        public ActionResult KefuNine()
        {
            return View();
        }

        /// <summary>
        /// 保存产品详情图片
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>

        public FileResult SaveImg(int no)
        {
            ProductBLL bll = new ProductBLL();
            ProductApiModel model = bll.GetProduct(no);
            if (model != null)
            {
                string imgPath = PublicClass.QrCode.CreateProductDetailQrCode(model.Url, model.Name);
                return File(imgPath, "application/image/jpeg", model.No + ".jpeg");
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 支付测试
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyTest()
        {
            return View();
        }

        /// <summary>
        /// 小额悬浮框详情
        /// </summary>
        /// <returns></returns>
        public ActionResult XiaoXuanfuDetailLeft()
        {
            return View();
        }

        /// <summary>
        /// 大额悬浮框详情
        /// </summary>
        /// <returns></returns>
        public ActionResult XuanfuDetailLeft()
        {
            return View();
        }

    }
}