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
using LoanMarket.PublicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class ProductBLL : BaseBLL
    {
        public List<ProductApiModel> FindProductList()
        {
            try
            {
                List<LoanMarketProduct> loanMarketProducts = product.FindProductList();
                return new List<ProductApiModel>(loanMarketProducts.ConvertAll<ProductApiModel>(e => { return new ProductApiModel { Id = e.Id, No = e.No, Name = e.Name, Icon = e.Icon }; }));
            }
            catch (Exception e)
            {
                log.Info("BLL-查询产品列表报异常，异常信息为：" + e.Message);
            }
            return null;
        }
        /// <summary>
        /// 查询产品列表 - 根据产品类别编号
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<ProductApiModel> FindProductListByType(int typeId)
        {
            try
            {
                List<LoanMarketProduct> loanMarketProducts = product.FindProductList();
                loanMarketProducts = loanMarketProducts.Where(a => a.TypeNo == typeId).ToList();
                return new List<ProductApiModel>(loanMarketProducts.ConvertAll<ProductApiModel>(e => { return new ProductApiModel { Id = e.Id, No = e.No, Name = e.Name, Icon = e.Icon }; }));
            }
            catch (Exception e)
            {
                log.Info("BLL-查询产品列表 - 根据产品类别编号。报异常，异常信息为：" + e.Message);
            }
            return null;
        }

        /// <summary>
        /// 查找产品 - 根据编号
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public ProductApiModel GetProduct(int no)
        {
            LoanMarketProduct marketProduct = product.GetProduct(no);
            log.Info("产品详情,二维码"+JsonConvert.SerializeObject(marketProduct));
            return new ProductApiModel()
            {
                No = marketProduct.No,
                Name = marketProduct.Name,
                Icon = marketProduct.Icon,
                Describe1 = marketProduct.Describe1,
                Describe2 = marketProduct.Describe2,
                Describe3 = marketProduct.Describe3,
                Describe4 = marketProduct.Describe4,
                Describe5 = marketProduct.Describe5,
                Url = marketProduct.Url,
                QrCodeUrl = QrCode.CreateQrCode(marketProduct.Url)
            };
        }
    }
}