using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class Test : ApiController
    {
        [Route("api/a")]
        public IEnumerable<string> a()
        {
            return new string[] { "value1", "value2" };
        }
        [Route(Name = "b")]
        public IEnumerable<string> b()
        {
            return new string[] { "value1", "value2" };
        }
        [Route(Name = "c")]
        public IEnumerable<string> c()
        {
            return new string[] { "value1", "value2" };
        }
        [Route(Name = "d")]
        public IEnumerable<string> d()
        {
            return new string[] { "value1", "value2" };
        }
    }
}