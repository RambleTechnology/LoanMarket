namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketUser")]
    public partial class LoanMarketUser
    {
        [StringLength(100)]
        public string Id { get; set; }

        [Required]
        [StringLength(500)]
        public string NickName { get; set; }

        [Required]
        [StringLength(500)]
        public string RealName { get; set; }

        [StringLength(100)]
        public string Mobile { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [StringLength(1000)]
        public string Icon { get; set; }

        public int? No { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        public int? IsPeculiarUser { get; set; }
        /// <summary>
        /// 可提现金额
        /// </summary>
        public decimal WithdrawAmount { get; set; }
    }
}
