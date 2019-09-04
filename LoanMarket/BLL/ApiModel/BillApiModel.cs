/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： BillApiModel
* 版本号： V1.0.0.0
* 唯一标识： 89e55e6e-cf9a-420d-9030-1143dd181c5d
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/1 16:59:14

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/1 16:59:14
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

namespace LoanMarket.BLL.ApiModel
{
    /// <summary>
    /// 推广佣金单 ApiModel
    /// </summary>
    public class BillApiModel
    {

        public string Id { get; set; }

        public string FromUserNo { get; set; }

        public string ToUserNo { get; set; }

        public decimal Amount { get; set; }

        public int BillType { get; set; }



    }
}