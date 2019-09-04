namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketGroup")]
    public partial class LoanMarketGroup
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int No { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string UpCondition { get; set; }

        public int? ParentNo { get; set; }

        [StringLength(100)]
        public string Pcode { get; set; }
    }
}
