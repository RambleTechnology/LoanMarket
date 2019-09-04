namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketProductType")]
    public partial class LoanMarketProductType
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int No { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public String PNo { get; set; }


        [StringLength(100)]
        public String ViewGrade { get; set; }

        [StringLength(500)]
        public string Icon { get; set; }
    }
}
