/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.PublicClass
* 文件名： QrCode
* 版本号： V1.0.0.0
* 唯一标识： 4e8ac420-f3d1-44d4-8440-ff6c93fc8b98
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/3 15:27:42

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/3 15:27:42
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using Spire.Barcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LoanMarket.PublicClass
{
    public class QrCode
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">二维码内容</param>
        /// <returns>二维码名称</returns>
        public static string CreateQrCode(string content)
        {
            //创建BarcodeSettings对象
            BarcodeSettings settings = new BarcodeSettings();
            //设置条码类型为二维码
            settings.Type = BarCodeType.QRCode;

            //设置二维码数据
            settings.Data = "http://www.jiaodai.online/Content/Images/banner/4.jpg";

            //设置显示文本
            settings.Data2D = "http://www.jiaodai.online/Content/Images/banner/4.jpg";

            //设置数据类型为数字
            settings.QRCodeDataMode = QRCodeDataMode.Numeric;

            //设置二维码错误修正级别
            settings.QRCodeECL = QRCodeECL.H;

            //设置宽度
            settings.X = 2.0f;

            //初始化BarCodeGenerator对象
            BarCodeGenerator generator = new BarCodeGenerator(settings);

            //创建图片并保存为PNG格式
            Image image = generator.GenerateImage();
            string rootPath = HttpContext.Current.Server.MapPath("~");
            string imgName = DateTime.Now.ToString("yyyMMddHHmmssffff") + ".png";
            string fullPath = rootPath + "Content\\Images\\QrCode\\" + imgName;
            image.Save(fullPath);
            return imgName;
        }
    }
}