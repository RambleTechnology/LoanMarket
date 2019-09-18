using LoanMarket.BLL.ApiModel;
using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class ProductDetailController : BaseApiController
    {

        /// <summary>
        /// 获取产品详情
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>        
        public ProductApiModel Get(int no)
        {
            log.Info("start-获取产品详情");
            PublicModels.User u = SessionTool.Get<PublicModels.User>("user");
            if (u != null)
            {
                log.Info("获取产品详情,已经登录");
                bool isPeculiar = user.CheckIsPeculiar((int)u.No);
                if (isPeculiar)
                {
                    log.Info("获取产品详情,已经登录，是会员");
                    return product.GetProduct(no);
                }
                else
                {
                    log.Info("获取产品详情,已经登录，不是会员");
                    return new ProductApiModel() { ResponseStatus = "不是会员" };
                }
            }
            else
            {
                log.Info("获取产品详情,未登录");
                return new ProductApiModel() { ResponseStatus = "未登录" };
            }
        }


    }
}