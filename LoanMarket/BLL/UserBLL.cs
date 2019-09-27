/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.BLL
* 文件名： UserBLL
* 版本号： V1.0.0.0
* 唯一标识： 61ee788b-fc19-4f8d-9a75-e69f4d3c4971
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/7/25 16:10:24

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/7/25 16:10:24
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using LoanMarket.Api.ParamModel;
using LoanMarket.BLL.ApiModel;
using LoanMarket.Models;
using LoanMarket.PublicClass;
using LoanMarket.PublicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMarket.BLL
{
    public class UserBLL : BaseBLL
    {
        /// <summary>
        /// 查找用户信息
        /// </summary>
        /// <returns></returns>
        public UserApiModel GetUserInfo(int userId)
        {
            UserApiModel apiModel = new UserApiModel();
            LoanMarketUser loanMarketUser = user.GetUser(userId);
            if (loanMarketUser != null && loanMarketUser.No > 0)
            {
                apiModel.Icon = loanMarketUser.Icon;
                apiModel.Mobile = loanMarketUser.Mobile;
                apiModel.NickName = loanMarketUser.NickName;
                apiModel.No = loanMarketUser.No;
                apiModel.RealName = loanMarketUser.RealName;
                apiModel.Sex = loanMarketUser.Sex;
            }
            return apiModel;
        }

        /// <summary>
        /// 查找用户信息 - 通过手机号
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public int GetUserInfo(string mobile)
        {
            LoanMarketUser marketUser = user.GetUser(mobile);
            if (marketUser != null)
            {
                return (int)marketUser.No;
            }
            else { return 0; }

        }

        /// <summary>
        /// 查找用户 - 通过手机号
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public User GetUserInfoByMobile(string mobile)
        {
            LoanMarketUser loanMarketUser = user.GetUser(mobile);
            if (loanMarketUser != null && loanMarketUser.No > 0)
            {
                return new User()
                {
                    No = loanMarketUser.No,
                    Icon = loanMarketUser.Icon,
                    Mobile = loanMarketUser.Mobile,
                    NickName = loanMarketUser.NickName,
                    RealName = loanMarketUser.RealName,
                    Sex = loanMarketUser.Sex
                };
            }
            else
            {
                return new User();
            }
        }

        /// <summary>
        /// 查找用户 - 根据手机号和密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserInfo(string mobile, string password)
        {
            LoanMarketUser loanMarketUser = user.GetUser(mobile, password);
            if (loanMarketUser != null && loanMarketUser.No > 0)
            {
                return new User()
                {
                    No = loanMarketUser.No,
                    Icon = loanMarketUser.Icon,
                    Mobile = loanMarketUser.Mobile,
                    NickName = loanMarketUser.NickName,
                    RealName = loanMarketUser.RealName,
                    Sex = loanMarketUser.Sex
                };
            }
            else
            {
                return new User();
            }
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="apiModel"></param>
        public void EditUser(UserApiModel apiModel)
        {
            LoanMarketUser loanMarketUser = new LoanMarketUser();
            if (apiModel != null && apiModel.No > 0)
            {
                loanMarketUser.Icon = apiModel.Icon;
                loanMarketUser.Mobile = apiModel.Mobile;
                loanMarketUser.NickName = apiModel.NickName;
                loanMarketUser.No = apiModel.No;
                loanMarketUser.RealName = apiModel.RealName;
                loanMarketUser.Sex = apiModel.Sex;
            }
            user.UpdateUser(loanMarketUser);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userParamModel"></param>
        /// <returns></returns>
        public int CreateUser(UserParamModel userParamModel)
        {
            //判断手机号是否已经存在
            if (user.GetUser(userParamModel.Mobile) != null)
            {
                return -1;
            }
            LoanMarketUser loanMarketUser = new LoanMarketUser() { Mobile = userParamModel.Mobile, Password = userParamModel.Password, NickName = userParamModel.NickName, RealName = userParamModel.RealName, Sex = userParamModel.Sex };
            loanMarketUser.Id = GuidTool.GenerateKey();
            loanMarketUser.Icon = "";
            loanMarketUser.Sex = "";
            var list = user.FindUser();
            loanMarketUser.No = list == null ? 1 : list.Count + 1;
            loanMarketUser.IsPeculiarUser = 0;
            return user.CreateUser(loanMarketUser);
        }

        /// <summary>
        /// 创建推广的用户
        /// </summary>
        /// <param name="userParamModel"></param>
        /// <returns></returns>
        public int CreateSpreadUser(RegisterParamModel userParamModel)
        {
            //判断手机号是否已经存在
            if (user.GetUser(userParamModel.Mobile) != null)
            {
                return -1;
            }
            LoanMarketUser loanMarketUser = new LoanMarketUser() { Mobile = userParamModel.Mobile, Password = userParamModel.Password, NickName = userParamModel.NickName, RealName = userParamModel.RealName, Sex = userParamModel.Sex };
            loanMarketUser.Id = GuidTool.GenerateKey();
            loanMarketUser.Icon = "";
            loanMarketUser.Sex = "";
            var list = user.FindUser();
            loanMarketUser.No = list == null ? 1 : list.Count + 1;
            loanMarketUser.IsPeculiarUser = 0;
            int userNo = user.CreateUser(loanMarketUser);
            log.Info("创建推广的用户，创建用户成功，新创建的用户编号为：" + userNo);
            if (userNo > 0)
            {
                SpreadBLL spreadBLL = new SpreadBLL();
                if (spreadBLL.CreateSpread(userParamModel.FromUserNo, userNo) > 0)
                {
                    log.Info("创建推广的用户，创建用户成功，绑定上级成功。");
                    return userNo;
                }
                else
                {
                    log.Info("创建推广的用户，创建用户成功，绑定上级失败。");
                    return -2;
                }
            }
            else
            {
                log.Info("创建推广的用户，创建用户失败。");
                return 0;
            }
        }



        /// <summary>
        /// 检查是否是会员
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool CheckIsPeculiar(int no)
        {
            LoanMarketUser loanMarketUser = user.GetUser(no);
            if (loanMarketUser != null && loanMarketUser.IsPeculiarUser == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}