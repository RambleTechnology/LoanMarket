using LoanMarket.BLL.ApiModel;
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
            return product.GetProduct(no);
        }


    }
}