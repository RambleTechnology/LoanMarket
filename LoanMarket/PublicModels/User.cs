/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.PublicModels
* 文件名： User
* 版本号： V1.0.0.0
* 唯一标识： db3375f8-98d2-47f4-a65d-749c2e7ca4ab
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/26 9:26:57

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/26 9:26:57
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

namespace LoanMarket.PublicModels
{
    public class User
    {
        public string NickName { get; set; }

        public string RealName { get; set; }

        public string Mobile { get; set; }

        public string Sex { get; set; }

        public string Icon { get; set; }

        public int? No { get; set; }
    }
}