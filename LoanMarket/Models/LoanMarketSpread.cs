namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketSpread")]
    public partial class LoanMarketSpread
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int FromUserNo { get; set; }

        public int ToUserNo { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
