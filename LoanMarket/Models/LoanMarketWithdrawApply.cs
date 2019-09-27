namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketWithdrawApply")]
    public partial class LoanMarketWithdrawApply
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int UserNo { get; set; }

        /// <summary>
        /// 可提现总金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 本次申请提现金额
        /// </summary>
        public decimal ApplyWithwrawAmount { get; set; }

        public string UserNickName { get; set; }

        public string UserRealName { get; set; }

        public string ZFBAccount { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 状态（提交申请；审核通过；审核失败）
        /// </summary>
        public string Status { get; set; }


        [StringLength(100)]
        public string SpareField1 { get; set; }





    }
}
