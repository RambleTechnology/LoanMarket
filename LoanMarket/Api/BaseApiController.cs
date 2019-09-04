/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.Api
* 文件名： BaseApiController
* 版本号： V1.0.0.0
* 唯一标识： 74691f77-d2e4-46c2-bef8-fd452cdf62b1
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/21 12:29:07

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/21 12:29:07
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.BLL;
using LoanMarket.PublicClass;
using log4net;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class BaseApiController : ApiController
    {

        protected ILog log = LogManager.GetLogger("log4net");

        //public static ICache cache = new RedisCache();

        protected ProductBLL product = new ProductBLL();
        protected ProductTypeBLL type = new ProductTypeBLL();
        protected UserBLL user = new UserBLL();
        protected ForumBLL forum = new ForumBLL();
        protected CommentBLL comment = new CommentBLL();
        protected SpreadBLL spread = new SpreadBLL();


    }
}