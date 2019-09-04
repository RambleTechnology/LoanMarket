using LoanMarket.Api.ParamModel;
using LoanMarket.PublicClass;
using LoanMarket.PublicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class LoginController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="value"></param>
        public string Post([FromBody] UserParamModel userParamModel)
        {
            if (userParamModel != null)
            {
                if (!string.IsNullOrEmpty(userParamModel.Mobile) && !string.IsNullOrEmpty(userParamModel.Password))
                {
                    User userInfo = user.GetUserInfo(userParamModel.Mobile, userParamModel.Password);
                    if (userInfo != null && userInfo.No > 0)
                    {
                        //缓存到redis
                        //cache.SetCache(userInfo.No.ToString(), userInfo);
                        SessionTool.Set("user", userInfo);
                        return "登录成功";
                    }
                    else
                    {
                        return "用户不存在或手机号和密码不匹配";
                    }
                }
                else
                {
                    return "用户名和密码不可为空";
                }
            }
            else
            {
                return "用户名和密码不可为空";
            }
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