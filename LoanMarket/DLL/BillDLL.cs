/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： BillDLL
* 版本号： V1.0.0.0
* 唯一标识： 79067a58-32ea-44a4-9bb6-3fa54743c4ec
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/1 16:56:11

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/1 16:56:11
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.DLL
{
    /// <summary>
    /// 推广佣金单
    /// </summary>
    public class BillDLL : BaseDLL
    {
        /// <summary>
        /// 创建推广佣金单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string CreateBill(LoanMarketSpreadBill model)
        {
            db.LoanMarketSpreadBill.Add(model);
            db.SaveChanges();
            return model.No;
        }

    }
}