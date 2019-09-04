namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketSpreadBill")]
    public partial class LoanMarketSpreadBill
    {
        [StringLength(100)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string No { get; set; }

        [Required]
        [StringLength(100)]
        public string FromUserNo { get; set; }

        [StringLength(100)]
        public string FromUserGroupNo { get; set; }

        [StringLength(100)]
        public string FromUserGroupName { get; set; }

        [Required]
        [StringLength(100)]
        public string ToUserNo { get; set; }

        [StringLength(100)]
        public string ToUserGroupNo { get; set; }

        [StringLength(100)]
        public string ToUserGroupName { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int BillType { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpateTime { get; set; }
    }
}
