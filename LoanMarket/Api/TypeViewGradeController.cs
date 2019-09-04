using LoanMarket.BLL.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMarket.Api
{
    public class TypeViewGradeController : BaseApiController
    {


        /// <summary>
        /// 查询类别信息 - 根据父级类别编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ProductTypeApiModel> Get(int id)
        {
            return type.FindTypeGradeByPNo(id);
        }



    }
}