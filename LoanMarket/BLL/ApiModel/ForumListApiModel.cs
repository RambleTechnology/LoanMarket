/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： ForumListApiModel
* 版本号： V1.0.0.0
* 唯一标识： 718404c8-0095-4b63-a12e-e0affe659bbd
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/30 13:39:17

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/30 13:39:17
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
    public class ForumListApiModel
    {

        public int? No { get; set; }

        public string Title { get; set; }
        public string ContentBody { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateUserNo { get; set; }

        public int? ViewCount { get; set; }

        public int? CommentCount { get; set; }

        public int? LikeCount { get; set; }
        

        /// <summary>
        /// 创建者用户图像
        /// </summary>
        public string CreateUserIcon { get; set; }

        /// <summary>
        /// 创建者用户昵称
        /// </summary>
        public string CreateUserNickName { get; set; }

    }
}