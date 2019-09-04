namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketProduct")]
    public partial class LoanMarketProduct
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int No { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Icon { get; set; }

        [StringLength(500)]
        public string Describe1 { get; set; }

        [StringLength(500)]
        public string Describe2 { get; set; }

        [StringLength(500)]
        public string Describe3 { get; set; }

        [StringLength(500)]
        public string Describe4 { get; set; }

        [StringLength(500)]
        public string Describe5 { get; set; }

        public int? TypeNo { get; set; }

        [StringLength(500)]
        public string Url { get; set; }
    }
}
