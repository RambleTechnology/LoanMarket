/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： BaseBLL
* 版本号： V1.0.0.0
* 唯一标识： 63ec945f-6fab-4431-b0d5-281a46b8e977
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/21 12:13:40

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/21 12:13:40
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.DLL;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class BaseBLL
    {
        protected ILog log = LogManager.GetLogger("log4net");

        protected ProductDLL product = new ProductDLL();
        protected ProductTypeDLL type = new ProductTypeDLL();

        protected UserDLL user = new UserDLL();

        protected ForumDLL forum = new ForumDLL();

        protected CommentDLL comment = new CommentDLL();

        protected SpreadDLL spread = new SpreadDLL();

        protected UserGroupDLL userGroup = new UserGroupDLL();

        protected BillDLL bill = new BillDLL();





        /// <summary>
        /// 查找推广返佣金额 - 根据用户组
        /// </summary>
        /// <param name="groupNo"></param>
        /// <returns></returns>
        public decimal GetSpreadAmountByUserGroupNo(int groupNo)
        {
            if (groupNo == 0) { return 0; }
            //上级代理为 vip  无推广佣金
            if (groupNo == 1) { return 0; }
            decimal amount = 0;
            switch (groupNo)
            {
                case 2:
                    amount = 5;
                    break;
                case 3:
                    amount = 10;
                    break;
                case 4:
                    amount = 15;
                    break;
                case 5:
                    amount = 25;
                    break;
                default:

                    break;
            }
            return amount;

        }

    }
}