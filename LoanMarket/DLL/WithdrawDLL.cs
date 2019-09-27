/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： UserGroupDLL
* 版本号： V1.0.0.0
* 唯一标识： 3e4cd206-9de4-4e28-8a22-371d3b5573e0
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/8/31 20:41:44

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/8/31 20:41:44
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.Models;
using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.DLL
{
    public class WithdrawDLL : BaseDLL
    {
        /// <summary>
        /// 新增或者修改提现密码
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Save(int userNo, string password)
        {
            LoanMarketUserWithdraw withdraw = db.LoanMarketUserWithdraw.Where(a => a.UserNo == userNo).FirstOrDefault();
            if (withdraw != null && withdraw.UserNo > 0)
            {
                withdraw.WithdrawPassword = password;
                return db.SaveChanges();
            }
            else
            {
                withdraw = new LoanMarketUserWithdraw();
                withdraw.Id = GuidTool.GenerateKey();
                withdraw.UserNo = userNo;
                withdraw.WithdrawPassword = password;
                db.LoanMarketUserWithdraw.Add(withdraw);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取提现密码
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public string GetWithdrawPassword(int userNo)
        {
            LoanMarketUserWithdraw withdraw = db.LoanMarketUserWithdraw.Where(a => a.UserNo == userNo).FirstOrDefault();
            return withdraw.WithdrawPassword;
        }
    }
}