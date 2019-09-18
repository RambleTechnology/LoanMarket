/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.Api.ParamModel
* 文件名： RegisterParamModel
* 版本号： V1.0.0.0
* 唯一标识： 16da37a9-1f0a-42fd-be87-9d3b33e0773d
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/18 19:19:02

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/18 19:19:02
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.Api.ParamModel
{
    public class RegisterParamModel
    {

        public string Mobile { get; set; }
        public string Password { get; set; }

        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }

        /// <summary>
        /// 上级推广人编号
        /// </summary>
        public int FromUserNo { get; set; }

        /// <summary>
        /// 上级推广人手机号
        /// </summary>
        public string FromUserMobile { get; set; }

    }
}