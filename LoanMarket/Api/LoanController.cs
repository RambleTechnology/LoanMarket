using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    
    public class LoanActionController : BaseApiController
    {
        /// <summary>
        /// 查询产品列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductApiModel> Get()
        {
            log.Info("api-获取产品列表");
            return product.FindProductList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}