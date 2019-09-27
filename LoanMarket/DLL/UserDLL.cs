/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： UserDLL
* 版本号： V1.0.0.0
* 唯一标识： 5f03395c-080f-49a0-9fb4-a2b867d0fcc7
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/25 16:13:00

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/25 16:13:00
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
    public class UserDLL : BaseDLL
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public List<LoanMarketUser> FindUser()
        {
            return db.LoanMarketUser.ToList();
        }


        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public LoanMarketUser GetUser(int userId)
        {
            return db.LoanMarketUser.Where(a => a.No == userId).FirstOrDefault();
        }

        /// <summary>
        /// 查找用户 - 根据手机号
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public LoanMarketUser GetUser(string mobile)
        {
            return db.LoanMarketUser.Where(a => a.Mobile == mobile).FirstOrDefault();
        }

        /// <summary>
        /// 查找用户 - 根据手机号和密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoanMarketUser GetUser(string mobile, string password)
        {
            return db.LoanMarketUser.Where(a => a.Mobile == mobile && a.Password == password).FirstOrDefault();
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        public void UpdateUser(LoanMarketUser user)
        {
            LoanMarketUser oldUser = db.LoanMarketUser.Where(a => a.No == user.No).FirstOrDefault();
            oldUser.Icon = user.Icon;
            oldUser.RealName = user.RealName;
            oldUser.NickName = user.NickName;
            oldUser.Mobile = user.Mobile;
            oldUser.Sex = user.Sex;
            db.SaveChanges();
        }

        /// <summary>
        /// 减少佣金
        /// </summary>
        /// <param name="user"></param>
        public int UpdateWithdrawAmount(LoanMarketUser user)
        {
            LoanMarketUser oldUser = db.LoanMarketUser.Where(a => a.No == user.No).FirstOrDefault();
            oldUser.WithdrawAmount = user.WithdrawAmount;
            return db.SaveChanges();
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="loanMarketUser"></param>
        /// <returns></returns>
        public int CreateUser(LoanMarketUser loanMarketUser)
        {
            db.LoanMarketUser.Add(loanMarketUser);
            db.SaveChanges();
            return (int)loanMarketUser.No;
        }


        /// <summary>
        /// 增加用户佣金
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int UpdateUserWithdrawAmount(int userNo, decimal amount)
        {
            LoanMarketUser loanMarketUser = db.LoanMarketUser.Where(a => a.No == userNo).FirstOrDefault();
            loanMarketUser.WithdrawAmount = loanMarketUser.WithdrawAmount + amount;
            return db.SaveChanges();
        }

    }
}