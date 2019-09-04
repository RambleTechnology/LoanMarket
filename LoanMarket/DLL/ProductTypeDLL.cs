/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.DLL
* 文件名： ProductDLL
* 版本号： V1.0.0.0
* 唯一标识： 6a890ec0-259d-4547-918b-a2275e17c886
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/21 12:09:38

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/21 12:09:38
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

    public class ProductTypeDLL : BaseDLL
    {
        public List<LoanMarketProductType> FindProductTypeList() { return db.LoanMarketProductType.ToList(); }

        public LoanMarketProductType GetProductType(int no) { return db.LoanMarketProductType.Where(a => a.No == no).FirstOrDefault(); }

        public List<LoanMarketProductType> FindTypeGradeByPNo(int pNo) {
            return db.LoanMarketProductType.Where(a => a.PNo == pNo.ToString()).ToList();
        }
    }
}