/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： BillTypeEnum
* 版本号： V1.0.0.0
* 唯一标识： 49137149-9103-4552-ad7e-5fc516bc3b0d
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/1 18:16:53

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/1 18:16:53
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

namespace LoanMarket.BLL
{
    /// <summary>
    /// 返佣单类型枚举
    /// </summary>
    public enum BillTypeEnum
    {
        直推 = 0,
        上级代理 = 1
    }
}