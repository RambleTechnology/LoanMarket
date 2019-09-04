/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： CommentListApiModel
* 版本号： V1.0.0.0
* 唯一标识： 6cd96286-f612-4aaf-9b6b-c8d078028aef
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/31 16:26:31

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/31 16:26:31
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
    public class CommentListApiModel
    {
        /// <summary>
        /// 评论编号
        /// </summary>
        public int? No { get; set; }

        /// <summary>
        /// 评论正文
        /// </summary>
        public string ContentBody { get; set; }

        /// <summary>
        /// 评论创建者用户编号
        /// </summary>
        public int? CommentUserNo { get; set; }

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 帖子编号
        /// </summary>
        public int? ForumNo { get; set; }

        /// <summary>
        /// 评论者用户昵称
        /// </summary>
        public string ContentUserNickName { get; set; }

        /// <summary>
        /// 评论创建者用户图像
        /// </summary>
        public string ContentUserIcon { get; set; }

    }
}