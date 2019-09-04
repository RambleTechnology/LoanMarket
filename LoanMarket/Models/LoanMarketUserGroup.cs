namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketUserGroup")]
    public partial class LoanMarketUserGroup
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int UserNo { get; set; }

        public int GroupNo { get; set; }
    }
}
