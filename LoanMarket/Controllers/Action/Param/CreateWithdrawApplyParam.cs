/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.Controllers.Action.Param
* 文件名： CreateWithdrawApplyParam
* 版本号： V1.0.0.0
* 唯一标识： 9a546358-c13d-408e-bd4e-ac528f9143e0
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/27 20:27:12

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/27 20:27:12
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanMarket.Controllers.Action.Param
{
    public class CreateWithdrawApplyParam
    {

        /// <summary>
        /// 本次申请提现金额
        /// </summary>
        [Required]
        public decimal ApplyWithwrawAmount { get; set; }
        [Required]
        public string ZFBAccount { get; set; }

        /// <summary>
        /// 提现密码
        /// </summary>
        [Required]
        public string WithdrawPassword { get; set; }

        public string SpareField1 { get; set; }

    }
}