using LoanMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class UserGroupController : BaseApiController
    {



        public LoanMarketGroup Get(int no)
        {
            return userGroup.GetUserGroup(no);
        }


    }
}