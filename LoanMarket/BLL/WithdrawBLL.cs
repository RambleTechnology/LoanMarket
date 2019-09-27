/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： WithdrawBLL
* 版本号： V1.0.0.0
* 唯一标识： ff614be2-dc63-4756-bbf3-68e35fa0e75f
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/27 15:17:04

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/27 15:17:04
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
    /// 提现密码-BLL
    /// </summary>
    public class WithdrawBLL : BaseBLL
    {
        /// <summary>
        /// 新增或者修改提现密码
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Save(int userNo, string password)
        {
            return withdraw.Save(userNo, password);
        }

        /// <summary>
        /// 获取提现密码
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public string GetWithdrawPassword(int userNo)
        {
            return withdraw.GetWithdrawPassword(userNo);
        }

    }
}