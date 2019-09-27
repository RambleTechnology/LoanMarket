using LoanMarket.BLL.ApiModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket.Controllers.Action
{
    public class CarjingController : BaseActionController
    {


        /// <summary>
        /// 搜索  帖子
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SearchArticle(string keyword, string type)
        {
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(type))
            {
                return json;
            }
            List<ForumListApiModel> list = new List<ForumListApiModel>();
            List<string> typeList = new List<string>();
            if (type == "forum")
            {
                // 交流专区  论坛
                typeList.Add("最新黑科技");
                typeList.Add("热门口子");
                typeList.Add("信用卡科技");
                typeList.Add("视频技术");
            }
            else if (type == "finance")
            {
                //财经
                typeList.Add("热门");
                typeList.Add("最新");
                typeList.Add("动态");
                typeList.Add("专栏");
            }
            else
            {
                return json;
            }
            list = forum.SearchForumList(keyword, typeList);
            json.Data = new { Status = "OK", Msg = "成功", Data = JsonConvert.SerializeObject(list) };
            return json;
        }
    }
}