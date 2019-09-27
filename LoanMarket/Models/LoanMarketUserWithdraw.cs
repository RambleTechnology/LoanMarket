namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketUserWithdraw")]
    public partial class LoanMarketUserWithdraw
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int UserNo { get; set; }

        [StringLength(1000)]
        public string WithdrawPassword { get; set; }

        [StringLength(100)]
        public string SpareField1 { get; set; }


        [StringLength(100)]
        public string SpareField2 { get; set; }



    }
}
