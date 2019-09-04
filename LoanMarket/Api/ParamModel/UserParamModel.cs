/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.Api.ParamModel
* 文件名： UserParamModel
* 版本号： V1.0.0.0
* 唯一标识： 7e250ad8-a401-4cd9-80e2-910ba601b83a
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/30 18:02:44

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/30 18:02:44
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
    public class UserParamModel
    {
        public string Mobile { get; set; }
        public string Password { get; set; }

        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }
    }
}