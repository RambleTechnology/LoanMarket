/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： BillBLL
* 版本号： V1.0.0.0
* 唯一标识： 5dc0948a-6979-4aca-b90d-af5966f0426b
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/1 16:56:28

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/1 16:56:28
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class BillBLL : BaseBLL
    {
        /// <summary>
        /// 创建推广佣金单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string CreateBill(BillApiModel model)
        {
            if (model == null) { return ""; }
            LoanMarketGroup fromGroup = userGroup.GetUserGroup(Convert.ToInt32(model.FromUserNo));
            LoanMarketGroup toGroup = userGroup.GetUserGroup(Convert.ToInt32(model.ToUserNo));
            LoanMarketSpreadBill spreadBill = new LoanMarketSpreadBill()
            {
                No = model.FromUserNo + "|" + model.ToUserNo + "|" + model.BillType.ToString() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"),
                BillType = model.BillType,
                Amount = model.Amount,
                Id = GuidTool.GenerateKey(),
                FromUserNo = model.FromUserNo,
                FromUserGroupNo = fromGroup.No.ToString(),
                FromUserGroupName = fromGroup.Name,
                ToUserNo = model.ToUserNo,
                ToUserGroupNo = toGroup == null ? "0" : toGroup.No.ToString(),
                ToUserGroupName = toGroup == null ? "非会员，无用户组" : toGroup.Name,
                CreateTime = DateTime.Now,
                UpateTime = DateTime.Now
            };
            string res = bill.CreateBill(spreadBill);
            //增加用户推广佣金
            if (user.UpdateUserWithdrawAmount(Convert.ToInt32(model.FromUserNo), model.Amount) > 0)
            {
                return res;
            }
            else
            {
                return string.Empty;
            }

        }
    }
}