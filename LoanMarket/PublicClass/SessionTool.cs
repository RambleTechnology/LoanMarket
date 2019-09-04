/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.PublicClass
* 文件名： SessionTool
* 版本号： V1.0.0.0
* 唯一标识： 5e0b5bd4-cf21-4be0-a447-9084d0cccbd7
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/31 18:34:01

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/31 18:34:01
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.PublicClass
{
    public class SessionTool
    {
        /// <summary>
        /// 添加Session,有效期为默认
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        public static void Add(string strSessionName, object objValue)
        {
            HttpContext.Current.Session[strSessionName] = JsonConvert.SerializeObject(objValue);
        }

        /// <summary>
        /// 添加Session，并设置有效期为分钟或几年
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        /// <param name="iExpires">分钟数：大于０则以分钟数为有效期，等于０则以后面的年为有效期</param>
        /// <param name="iYear">年数：当分钟数为０时按年数为有效期，当分钟数大于０时此参数随意设置</param>
        public static void Set(string strSessionName, object objValue, int iExpires = 240, int iYear = 0)
        {
            HttpContext.Current.Session[strSessionName] = JsonConvert.SerializeObject(objValue);
            if (iExpires > 0)
            {
                HttpContext.Current.Session.Timeout = iExpires;
            }
            else if (iYear > 0)
            {
                HttpContext.Current.Session.Timeout = 60 * 24 * 365 * iYear;
            }
        }




        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static object Get(string strSessionName)
        {
            return HttpContext.Current.Session[strSessionName];
        }

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static T Get<T>(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] != null && !string.IsNullOrEmpty(HttpContext.Current.Session[strSessionName].ToString()))
            {
                return JsonConvert.DeserializeObject<T>(HttpContext.Current.Session[strSessionName].ToString());
            }
            else
            {
                return default(T);
            }
        }


        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void Remove(string strSessionName)
        {
            HttpContext.Current.Session.Remove(strSessionName);
        }

        /// <summary>
        /// 清空所有Session
        /// </summary>
        public static void RemoveAll()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}