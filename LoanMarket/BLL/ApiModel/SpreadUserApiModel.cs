/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： SpreadUser
* 版本号： V1.0.0.0
* 唯一标识： 93caa3cc-6842-4326-9deb-d1705826820e
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/21 11:23:27

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/21 11:23:27
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
    public class SpreadUserApiModel
    {
        public string NickName { get; set; }
        public string Mobile { get; set; }

        /// <summary>
        /// 被推广人用户编号
        /// </summary>
        public int ToUserNo { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否是会员
        /// </summary>
        public bool IsPeculiarUser { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public string UserGroupName { get; set; }

    }
}