using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LoanMarket.Api
{
    /// <summary>
    /// 论坛 api
    /// </summary>
    public class ForumController : BaseApiController
    {
        /// <summary>
        /// 帖子列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ForumListApiModel> Get()
        {
            return forum.FindForumList();
        }

        /// <summary>
        /// 帖子详情
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public ForumDetailApiModel Get(int no)
        {
            return forum.GetForumDetail(no);
        }

        /// <summary>
        /// 新增帖子
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]ForumDetailApiModel detail)
        {
            forum.CreateForum(detail);
        }

        /// <summary>
        /// 修改浏览量、评论量、点赞量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int no )
        {            
            forum.AddView(no);
        }


    }
}