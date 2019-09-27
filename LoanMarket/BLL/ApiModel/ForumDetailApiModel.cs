/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： ForumDetailApiModel
* 版本号： V1.0.0.0
* 唯一标识： 4c417682-9185-4bf6-b927-6162738c591d
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/30 13:39:50

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/30 13:39:50
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
    public class ForumDetailApiModel
    {
        public int? No { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string ContentBody { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateUserNo { get; set; }

        public int? ViewCount { get; set; } = 0;

        public int? CommentCount { get; set; } = 0;

        public int? LikeCount { get; set; } = 0;

        public DateTime? UpdateTime { get; set; }


        /// <summary>
        /// 状态：0：未审核；1：可用
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// 创建者用户图像
        /// </summary>
        public string CreateUserIcon { get; set; }

        /// <summary>
        /// 创建者用户昵称
        /// </summary>
        public string CreateUserNickName { get; set; }

        /// <summary>
        /// 附图1
        /// </summary>
        public string CarryImg1 { get; set; }


        /// <summary>
        /// 附图2
        /// </summary>
        public string CarryImg2 { get; set; }
    }
}