/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL.ApiModel
* 文件名： ProductApiModel
* 版本号： V1.0.0.0
* 唯一标识： 3fb657b7-aa24-4f4b-97d8-575981f42cf6
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/21 12:16:19

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/21 12:16:19
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL.ApiModel
{
    public class ProductApiModel
    {
        public string Id { get; set; }

        public int No { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }


        public string Icon { get; set; }


        public string Describe1 { get; set; }

        public string Describe2 { get; set; }

        public string Describe3 { get; set; }

        public string Describe4 { get; set; }

        public string Describe5 { get; set; }

        public string QrCodeUrl { get; set; }
    }
}