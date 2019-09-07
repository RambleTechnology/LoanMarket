/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： ForumBLL
* 版本号： V1.0.0.0
* 唯一标识： ffc83fc7-321a-4302-9a22-50a646cf2bad
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/30 13:38:34

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/30 13:38:34
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using LoanMarket.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    /// <summary>
    /// 论坛 bll
    /// </summary>
    public class ForumBLL : BaseBLL
    {
        /// <summary>
        /// 查询 帖子列表
        /// </summary>
        /// <returns></returns>
        public List<ForumListApiModel> FindForumList()
        {
            List<LoanMarketForum> list = forum.FindForumList();
            List<ForumListApiModel> data = new List<ForumListApiModel>(list.ConvertAll<ForumListApiModel>(e =>
            {
                return new ForumListApiModel
                {
                    No = e.No,
                    CommentCount = e.CommentCount,
                    ContentBody = e.ContentBody,
                    CreateTime = e.CreateTime,
                    CreateUserNo = e.CreateUserNo,
                    LikeCount = e.LikeCount,
                    ViewCount = e.ViewCount,
                    Title = e.Title,
                    CreateUserNickName = e.CreateUserNo > 0 ? user.GetUser((int)e.CreateUserNo).NickName : user.GetUser(1).NickName
                };
            }));
            return data;
        }

        /// <summary>   
        /// 查询 帖子列表 - 根据 type
        /// </summary>
        /// <returns></returns>
        public List<ForumListApiModel> FindForumList(string type)
        {
            List<LoanMarketForum> list = forum.FindForumList().Where(a => a.Type == type).ToList();
            List<ForumListApiModel> data = new List<ForumListApiModel>(list.ConvertAll<ForumListApiModel>(e =>
            {
                return new ForumListApiModel
                {
                    No = e.No,
                    CommentCount = e.CommentCount,
                    ContentBody = e.ContentBody,
                    CreateTime = e.CreateTime,
                    CreateUserNo = e.CreateUserNo,
                    LikeCount = e.LikeCount,
                    ViewCount = e.ViewCount,
                    Title = e.Title,
                    CreateUserNickName = e.CreateUserNo > 0 ? user.GetUser((int)e.CreateUserNo).NickName : user.GetUser(1).NickName
                };
            }));
            return data;
        }

        /// <summary>
        /// 查找帖子详情
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public ForumDetailApiModel GetForumDetail(int no)
        {
            LoanMarketForum e = forum.GetForumDetail(no);
            ForumDetailApiModel data = new ForumDetailApiModel() { No = e.No, CommentCount = e.CommentCount, ContentBody = e.ContentBody, CreateTime = e.CreateTime, CreateUserNo = e.CreateUserNo, LikeCount = e.LikeCount, ViewCount = e.ViewCount, Title = e.Title };
            data.CreateUserNickName = e.CreateUserNo > 0 ? user.GetUser((int)e.CreateUserNo).NickName : user.GetUser(1).NickName;
            return data;
        }

        /// <summary>
        /// 创建帖子
        /// </summary>
        public void CreateForum(ForumDetailApiModel detail)
        {
            detail.No = forum.FindForumList().Count + 1;
            LoanMarketForum loanMarketForum = new LoanMarketForum() { ContentBody = detail.ContentBody, CreateTime = DateTime.Now, CreateUserNo = detail.CreateUserNo, Id = GuidTool.GenerateKey(), Title = detail.Title, No = detail.No, UpdateTime = DateTime.Now, ViewCount = 0, CommentCount = 0, LikeCount = 0 };
            forum.CreateForum(loanMarketForum);
        }

        public void AddView(int no)
        {
            LoanMarketForum loanMarketForum = forum.GetForumDetail(no);
            loanMarketForum.ViewCount += 1;
            forum.UpdateForum(loanMarketForum);
        }

    }
}