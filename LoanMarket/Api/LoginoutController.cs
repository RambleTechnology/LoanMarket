using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class LoginoutController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public void Get(int no)
        {
            //移除redis 中缓存的用户信息
            //cache.RemoveCache(no.ToString());
            SessionTool.Remove("user");
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