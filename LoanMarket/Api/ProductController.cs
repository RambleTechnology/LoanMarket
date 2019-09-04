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
    public class ProductController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<ProductApiModel> Get(int typeId)
        {            
            return product.FindProductListByType(typeId);
        }

       
    }
}