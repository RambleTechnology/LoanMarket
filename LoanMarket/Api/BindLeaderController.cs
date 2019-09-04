using LoanMarket.Api.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class BindLeaderController : BaseApiController
    {

        /// <summary>
        /// 绑定上级
        /// </summary>
        /// <param name="model"></param>
        public string Post([FromBody]BindLeaderParamModel model)
        {
            int fromUserNo = user.GetUserInfo(model.mobile);
            if (fromUserNo == 0)
            {
                return "根据手机号查询不到用户";
            }
            int toUserNo = model.userNo;
            if (spread.CreateSpread(fromUserNo, toUserNo) > 0)
            {
                return "绑定成功";
            }
            else
            {
                return "绑定失败";
            }
        }

    }
}