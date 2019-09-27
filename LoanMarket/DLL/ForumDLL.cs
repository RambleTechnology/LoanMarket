/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： ForumDLL
* 版本号： V1.0.0.0
* 唯一标识： cd3f1c6c-20b4-4754-b5fd-b35f5e9f438f
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/30 13:32:56

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/30 13:32:56
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
    /// <summary>
    /// 论坛 dll
    /// </summary>
    public class ForumDLL : BaseDLL
    {
        /// <summary>
        /// 查询帖子 - 根据创建时间倒序
        /// </summary>
        /// <returns></returns>
        public List<LoanMarketForum> FindForumList()
        {
            return db.LoanMarketForum.OrderByDescending(a => a.CreateTime).ToList();
        }

        /// <summary>
        /// 搜索帖子
        /// </summary>
        /// <returns></returns>
        public List<LoanMarketForum> FindForumByKeyword(string keyword)
        {
            return db.LoanMarketForum
                .Where(a => a.Title.Contains(keyword))
                .OrderByDescending(a => a.CreateTime).ToList();
        }

        /// <summary>
        /// 查找帖子详情
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public LoanMarketForum GetForumDetail(int no)
        {
            return db.LoanMarketForum.Where(a => a.No == no).FirstOrDefault();
        }

        /// <summary>
        /// 新增帖子
        /// </summary>
        /// <param name="loanMarketForum"></param>
        public void CreateForum(LoanMarketForum loanMarketForum)
        {
            db.LoanMarketForum.Add(loanMarketForum);
            db.SaveChanges();
        }

        /// <summary>
        /// 更新 帖子
        /// </summary>
        /// <param name="loanMarketForum"></param>
        public void UpdateForum(LoanMarketForum loanMarketForum)
        {
            LoanMarketForum old = db.LoanMarketForum.Where(a => a.No == loanMarketForum.No).FirstOrDefault();
            old.ViewCount = loanMarketForum.ViewCount;
            old.CommentCount = loanMarketForum.CommentCount;
            old.LikeCount = loanMarketForum.LikeCount;
            db.SaveChanges();
        }

    }
}