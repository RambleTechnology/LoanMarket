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

    public class ProductTypeController : BaseApiController
    {

        /// <summary>
        /// 查询所有类别
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductTypeApiModel> Get()
        {
            return type.FindProductTypeList();
        }

        /// <summary>
        /// 获取类别详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductTypeApiModel Get(int no)
        {
            return type.GetProductType(no);
        }




    }
}