using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class HeiKejiController : BaseApiController
    {
        /// <summary>
        /// 根据类别查询
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ForumListApiModel> Get(string type)
        {
            return forum.FindForumList(type);
        }


    }
}