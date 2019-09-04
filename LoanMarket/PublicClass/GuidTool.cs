﻿/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.PublicClass
* 文件名： GuidTool
* 版本号： V1.0.0.0
* 唯一标识： 45f8ca1a-5f5f-48c9-a145-2a091182c991
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/30 14:26:59

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/30 14:26:59
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

namespace LoanMarket.PublicClass
{
    public static class GuidTool
    {
        public static string GenerateKey()
        {
            return Guid.NewGuid().ToSequentialGuid().ToUpper();
        }
    }
}