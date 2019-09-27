/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.PublicClass
* 文件名： VerifyCode
* 版本号： V1.0.0.0
* 唯一标识： 50d85ae4-6e22-45b2-87f8-e4b811f8877e
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/23 14:01:13

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/23 14:01:13
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace LoanMarket.PublicClass
{
    public class VerifyCode
    {
        /// <summary>
        /// 生成图片验证，并将验证代码保存到session[verifyCode]
        /// </summary>
        /// <returns>图片字节流</returns>
        public byte[] GetVerifyCode()
        {
            int codeW = 80;
            int codeH = 30;
            int fontSize = 16;
            string chkCode = string.Empty;
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.DarkBlue };
            string[] font = { "Times New Roman" };
            char[] character = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            //生成验证码字符串
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                chkCode += character[rnd.Next(character.Length)];
            }
            //写入Session用于验证码校验，可以对校验码进行加密，提高安全性
            //System.Web.HttpContext.Current.Session["verifyCode"] = chkCode;
            PublicClass.SessionTool.Set("verifyCode", chkCode);
            //创建画布
            Bitmap bmp = new Bitmap(codeW, codeH - 3);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);


            //画噪线
            for (int i = 0; i < 3; i++)
            {
                int x1 = rnd.Next(codeW);
                int y1 = rnd.Next(codeH);
                int x2 = rnd.Next(codeW);
                int y2 = rnd.Next(codeH);

                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码
            for (int i = 0; i < chkCode.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, fontSize);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 18, (float)0);
            }
            //将验证码写入图片内存流中，以image/png格式输出
            MemoryStream ms = new MemoryStream();
            try
            {
                bmp.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                g.Dispose();
                bmp.Dispose();
                ms.Dispose();
            }
        }
    }
}