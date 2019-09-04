using LoanMarket.Api.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class RegisterController : BaseApiController
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
        /// 注册
        /// </summary>
        /// <param name="userParamModel"></param>
        /// <returns></returns>
        public string Post([FromBody]UserParamModel userParamModel)
        {
            if (userParamModel == null)
            {
                return "手机号不可为空";
            }
            if (string.IsNullOrEmpty(userParamModel.Mobile))
            {
                return "手机号不可为空";
            }
            if (string.IsNullOrEmpty(userParamModel.NickName))
            {
                return "昵称不可为空";
            }
            if (string.IsNullOrEmpty(userParamModel.RealName))
            {
                return "真实姓名不可为空";
            }
            if (string.IsNullOrEmpty(userParamModel.Password))
            {
                return "密码不可为空";
            }
            int no = user.CreateUser(userParamModel);
            if (no > 0)
            {
                return "注册成功";
            }
            else if (no == 0)
            {
                return "注册失败";
            }
            else if (no == -1)
            {
                return "手机号已经注册";
            }
            else
            {
                log.Info("注册，逻辑异常，bll返回值为" + no);
                return "注册失败，服务异常";
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