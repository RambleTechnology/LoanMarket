using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class ForumViewController : BaseApiController
    {
      

        /// <summary>
        /// 增加 浏览量
        /// </summary>
        /// <param name="no"></param>
        public void Get(int no)
        {
            forum.AddView(no);
        }

       
    }
}