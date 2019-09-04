/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： BaseDLL
* 版本号： V1.0.0.0
* 唯一标识： 6faedacd-288f-427f-9fdb-bbdd29f7c0ae
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/21 12:10:04

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/21 12:10:04
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.DLL
{
    public class BaseDLL
    {
        protected Db db = new Db();

        protected ILog log = LogManager.GetLogger("businessLog");
    }
}