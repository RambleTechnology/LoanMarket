using LoanMarket.Api.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class SpreadRegisterController : BaseApiController
    {
        /// <summary>
        /// 注册 - 通过推广的链接
        /// </summary>
        /// <param name="userParamModel"></param>
        /// <returns></returns>
        public string Post([FromBody]RegisterParamModel userParamModel)
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
            if (userParamModel.FromUserNo == 0)
            {
                return "获取上级推广人失败";
            }
            int no = user.CreateSpreadUser(userParamModel);
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
            else if (no == -2)
            {
                return "注册成功，绑定上级推广人失败。";
            }
            else
            {
                log.Info("注册，逻辑异常，bll返回值为" + no);
                return "注册失败，服务异常";
            }
        }
    }
}