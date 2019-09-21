/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：LoanMarket.AliPay
* 文件名： config
* 版本号： V1.0.0.0
* 唯一标识： 78bfd184-e135-4061-a8c7-a1566dd29a0a
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/9/20 9:59:50

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/9/20 9:59:50
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

namespace LoanMarket.AliPay
{
    public class config
    {
        public config()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        // 应用ID,您的APPID
        public static string app_id = "2019091967572732";

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        // 商户私钥，您的原始格式RSA私钥
        public static string private_key = "MIIEpAIBAAKCAQEAp8z7TDttIE2/cPeItYwsA8GXSZiqeParokIqvy3/K8GYZl1eA5ot+F4xF6sFnAykIcDctzpVkjilfy6Kc8X8DzeSkGA6ce8Yg8mSKpfapoNI1zboBSYIe0UTxhlqmertJPHa0sEazB36qVWiX7DiQy7nSwh3waGMcMe2XQCMhdCLoXruYR5VoFW3Cz2ubt1awahLTLbeyQ/1UTGbjMHQsG/nHGlxfV17OGAseBxUiaTF0DqVRSafeO1f/U2rLK31HfMIGPtBo36cH9+gvbWSE7XBK84Qu2RhmUnR74q4hHMar2goCaPu4TBBxsYW8IhdP1HS3/SDXwwTjFTb67ErXQIDAQABAoIBABuFjk4BjTN4LQcdQmnsdKelD+g9RvCSHLJ/Qb2bkLefiBx6Adp7ZkDPSiQEo+XlWOJEXK8cvT4/Vj2W55R3i5D/X2WYst1PBulOnU+pGm6nJ8JMuh9mDowRV13te0OFeaHOnUJl87w4yo0Ng5VIUMQOJFd1KxcyJPO2fd2hImsr9jrcI87Mizj+mPEJIDPKwl+twzcQFkgv7BFM7zJlw5mZ6RWuC770JWw1A8LEZKPv4KmpfNfOUum9soA3VEbGCSiand65KhOf8yfo83fCFRQvUTHdvBG1Xhah1xVzfmbqYEs5tpY+XpBoARL8Q2HH6X938WgPLqaCuBsxK7YwaGECgYEA2SxQiINQzEZ40NMhWlnOR5Wgtq4oZZo6KGazEqHskokXc0u2sZrzwKF/ZjATfxMikieIusz1u6fGkBePJpsqqJdm3FeEcDC5q4ysottVJn3jwfBCdkDMUE57AmEY8ohS/xx34wT0Z8hQ0CAi1QjKY04/4Q+PmdfLLAucdcGHcIUCgYEAxcz3ju1MgACUkjRYmfwTnq06pRqz+cKJxe67xzZnEbpTpiYHSWw9X8sxFVsz7nAvWtj3bqWOirICZDPptWm1aOYy2Vf7Q79EJaohsTQBX7HRlUUlGaWMSIu1Z9qYQ4ixmH/QYlxguX9dNKhwkWD1mrEW4KR8qfJMZJBKG9Nr8vkCgYA5WQRjKBn791gL/NS/4RshuBdaZh7wxYs6A/ShpPSttVnl7kZuG/bmFT9pIqTjV5A3fA0VFu6FAUbj4fTBQxQ+tMxKvymP3q4I6Prlfnm70l6EZgeG5pGNW0wMUsudr/YKu9/EqRhJF5KPgwzvqISZOJ6RteQ7wco69U35ooM7aQKBgQCWIDwgibDPUiFxWjOJI86MV3Q0TbEdtm41AT4aNAtEZEQKzcAoFPP8Gc82I1Ol/BWlARnDK/qk//haryAJpaKfbGBZn7JAOBHz+E28HfmQ9PhaL/G5pnFzuj3EBiAc2cnZMeEqVmy/PZCzX8iYPpwKfbAcbhuELTeX9/+XYP8EmQKBgQCPkPG3UfgRVZCGtno+ydtsojtWtyQ9SK4vZSGAPJ/2wklXKLGBJwwQ/+irEHvRPkWBmGzGbOnZEtM6uG4wtD1+qgQhkB8RtlJZKow2sz7w+EzyuMH2h2/CLNTuyNEvBkZXcvzmwMuHB8J33M26yxcntMa7RWD1WrsSPeqdkYmsxQ==";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArlwhAvGMfF+pC/B7CrpR9feAAwltwW+AR6OExPHoFCzL+NeO/P79tg/mJkwTNSqWKLR93Yrv/Dh6g7FEt5mS8TPrb+aTLwI57vsiFCfUGSFxYYJ3ci5B29/IliqHcJk+w8tyernfSkcMG1rxESY4xJgY2mtkb7sWRRAKw5BI+dyzw/t5NP5h41XKlxbTzNBBPCLTNSKXi/4t2DzkZ4Sj6KKBDtZhL2Gv9KBhgVBIpJHsXR/njpYd4O9J3RVnt11PT8PWvd0Ix95TMs2In6ndQ6hR19nurJO4mBJsr8+6UrXAroAQfl5EaTGySye/e93NgJqFCEy2kMimmqCl3t6lHwIDAQAB";

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";
    }
}