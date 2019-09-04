/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： ProductDLL
* 版本号： V1.0.0.0
* 唯一标识： d69ce3a0-d63c-45fa-8cba-1eec3d8cd52d
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/21 12:14:52

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/21 12:14:52
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class ProductTypeBLL : BaseBLL
    {
        /// <summary>
        /// 查询类别列表
        /// </summary>
        /// <returns></returns>
        public List<ProductTypeApiModel> FindProductTypeList()
        {
            try
            {
                List<LoanMarketProductType> loanMarketProducts = type.FindProductTypeList();
                return new List<ProductTypeApiModel>(loanMarketProducts.ConvertAll<ProductTypeApiModel>(e => { return new ProductTypeApiModel { No = e.No, Name = e.Name, Icon = e.Icon }; }));
            }
            catch (Exception e)
            {
                log.Info("BLL-查询产品类别列表报异常，异常信息为：" + e.Message);
            }
            return null;
        }

        /// <summary>
        /// 获取类别性情
        /// </summary>
        /// <returns></returns>
        public ProductTypeApiModel GetProductType(int no)
        {
            LoanMarketProductType loanMarketProductType = type.GetProductType(no);
            return new ProductTypeApiModel() { No = loanMarketProductType.No, Name = loanMarketProductType.Name };
        }


        /// <summary>
        /// 查询类别信息 - 根据父级类别编号
        /// </summary>
        /// <param name="pNo"></param>
        /// <returns></returns>
        public List<ProductTypeApiModel> FindTypeGradeByPNo(int pNo)
        {
            List<LoanMarketProductType> loanMarketProducts = type.FindTypeGradeByPNo(pNo);
            return new List<ProductTypeApiModel>(loanMarketProducts.ConvertAll<ProductTypeApiModel>(e => { return new ProductTypeApiModel { No = e.No, Name = e.Name,Icon=e.Icon }; }));

        }

    }
}