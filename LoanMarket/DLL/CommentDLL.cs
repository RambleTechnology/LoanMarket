/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： CommentDLL
* 版本号： V1.0.0.0
* 唯一标识： d02725c3-41e5-462a-b98f-3d0e482b83ef
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/31 16:14:41

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/31 16:14:41
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
    public class CommentDLL : BaseDLL
    {

        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="loanMarketComment"></param>
        public void CreateComment(LoanMarketComment loanMarketComment)
        {
            db.LoanMarketComment.Add(loanMarketComment);
            db.SaveChanges();
        }

        /// <summary>
        /// 查询评论 - 根据帖子编号
        /// </summary>
        /// <param name="forumNo"></param>
        /// <returns></returns>
        public List<LoanMarketComment> FindCommentByForumNo(int forumNo)
        {
            return db.LoanMarketComment.Where(a => a.ForumNo == forumNo).ToList();
        }

        /// <summary>
        /// 查询评论
        /// </summary>
        /// <returns></returns>
        public List<LoanMarketComment> FindComment()
        {
            return db.LoanMarketComment.ToList();
        }


    }
}