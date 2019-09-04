namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketComment")]
    public partial class LoanMarketComment
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int? No { get; set; }

        [StringLength(1000)]
        public string ContentBody { get; set; }

        public int? CommentUserNo { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ForumNo { get; set; }

        public int? CreateUserNo { get; set; }
    }
}
