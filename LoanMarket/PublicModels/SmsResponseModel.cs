/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.PublicModels
* 文件名： SmsResponseModel
* 版本号： V1.0.0.0
* 唯一标识： 7af5da5e-c772-485c-821a-ddb93bbb14e0
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/23 15:01:37

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/23 15:01:37
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
    /// <summary>
    /// 发送短信响应报文实体
    /// </summary>
    public class SmsResponseModel
    {
        /// <summary>
        /// 请求状态码。
        /// 返回OK代表请求成功。
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 状态码的描述。
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求ID。
        /// F655A8D5-B967-440B-8683-DAD6FF8DE990
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 发送回执ID，可根据该ID在接口QuerySendDetails中查询具体的发送状态
        /// 900619746936498440^0
        /// </summary>
        public string BizId { get; set; }
    }
}