/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： CommentBLL
* 版本号： V1.0.0.0
* 唯一标识： 8413801c-9d7e-47d7-8c07-62a72696687b
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/31 16:15:04

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/31 16:15:04
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.Api.ParamModel;
using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class CommentBLL : BaseBLL
    {
        /// <summary>
        /// 查询评论 - 根据帖子编号
        /// </summary>
        /// <param name="forumNo"></param>
        /// <returns></returns>
        public List<CommentListApiModel> FindCommentByForumNo(int forumNo)
        {
            List<LoanMarketComment> list = comment.FindCommentByForumNo(forumNo);
            List<CommentListApiModel> commentListApiModels = new List<CommentListApiModel>(list.ConvertAll<CommentListApiModel>(e =>
          {
              return new CommentListApiModel
              {
                  CommentUserNo = e.CommentUserNo,
                  ContentBody = e.ContentBody,
                  CreateTime = e.CreateTime,
                  ForumNo = e.ForumNo,
                  No = e.No,
                  ContentUserIcon = user.GetUser((int)e.CommentUserNo).Icon,
                  ContentUserNickName = user.GetUser((int)e.CommentUserNo).NickName,
              };
          }));
            return commentListApiModels;
        }

        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="commentListApiModel"></param>
        public void CreateComment(CommentParamModel commentParamModel)
        {
            LoanMarketComment loanMarketComment = new LoanMarketComment()
            {
                CommentUserNo = commentParamModel.CommentUserNo,
                ContentBody = commentParamModel.ContentBody,
                CreateTime = DateTime.Now,
                ForumNo = commentParamModel.ForumNo,
                Id = GuidTool.GenerateKey(),
                No = comment.FindComment() == null ? 1 : comment.FindComment().Count + 1
            };
            comment.CreateComment(loanMarketComment);
        }


    }
}