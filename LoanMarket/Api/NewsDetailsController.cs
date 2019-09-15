using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class NewsDetailsController : BaseApiController
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ForumDetailApiModel Get(int no)
        {
            return forum.GetForumDetail(no);
        }


    }
}