/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： WithdrawApplyApiModel
* 版本号： V1.0.0.0
* 唯一标识： c67af1e3-56c7-446a-bc7e-0639093b2e30
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/27 20:13:14

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/27 20:13:14
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
    public class WithdrawApplyApiModel
    {
        public string Id { get; set; }

        public int UserNo { get; set; }

        /// <summary>
        /// 可提现总金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 本次申请提现金额
        /// </summary>
        public decimal ApplyWithwrawAmount { get; set; }

        public string UserNickName { get; set; }

        public string UserRealName { get; set; }

        public string ZFBAccount { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 状态（提交申请；审核通过；审核失败）
        /// </summary>
        public string Status { get; set; }

        
        public string SpareField1 { get; set; }
    }
}