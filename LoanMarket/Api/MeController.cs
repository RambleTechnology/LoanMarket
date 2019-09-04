using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class MeController : BaseApiController
    {


        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserApiModel Get(int userId)
        {
            return user.GetUserInfo(userId);
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]UserApiModel userApiModel)
        {
            user.EditUser(userApiModel);
        }

    }
}