/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.Api.ParamModel
* 文件名： CommentParamModel
* 版本号： V1.0.0.0
* 唯一标识： bc20dcfb-6a12-4fb3-bc1a-b138dc91818a
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/31 17:00:06

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/31 17:00:06
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

namespace LoanMarket.Api.ParamModel
{
    public class CommentParamModel
    {   /// <summary>
        /// 评论正文
        /// </summary>
        public string ContentBody { get; set; }

        /// <summary>
        /// 评论创建者用户编号
        /// </summary>
        public int? CommentUserNo { get; set; }        

        /// <summary>
        /// 帖子编号
        /// </summary>
        public int? ForumNo { get; set; }

    }
}