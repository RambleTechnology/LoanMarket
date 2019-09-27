/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： SpreadDLL
* 版本号： V1.0.0.0
* 唯一标识： e1438a7e-e8d2-4552-919a-38943c42c7ae
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/8/31 20:41:27

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/8/31 20:41:27
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
    public class SpreadDLL : BaseDLL
    {
        /// <summary>
        /// 创建用户推广
        /// </summary>
        /// <param name="model"></param>
        public void CreateSpread(LoanMarketSpread model)
        {
            db.LoanMarketSpread.Add(model);
            db.SaveChanges();
        }

        /// <summary>
        /// 查找推广人数
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public int GetSpreadCount(int userNo)
        {
            List<LoanMarketSpread> data = db.LoanMarketSpread.Where(a => a.FromUserNo == userNo).ToList(); ;
            if (data != null && data.Count > 0)
            {
                return data.Count;
            }
            else
            {
                return 0;
            }
        }

        public List<LoanMarketSpread> FindSpreadUser(int no)
        {
            return db.LoanMarketSpread.Where(a => a.FromUserNo == no).ToList();
        }


        /// <summary>
        /// 查找用户上级代理
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        public List<LoanMarketSpread> FindUserLeaders(int userNo)
        {
            return db.LoanMarketSpread.Where(a => a.ToUserNo == userNo).ToList();
        }

        /// <summary>
        /// 查询用户推广金
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public decimal GetMySpreadMoney(string no)
        {
            return db.LoanMarketSpreadBill.Where(a => a.FromUserNo == no).Sum(a => a.Amount);
        }

    }
}