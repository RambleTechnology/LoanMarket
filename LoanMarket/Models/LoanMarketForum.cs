namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketForum")]
    public partial class LoanMarketForum
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int? No { get; set; }

        [StringLength(10)]
        public string Title { get; set; }

        public string Type { get; set; }

        public string ContentBody { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateUserNo { get; set; }

        public int? ViewCount { get; set; }

        public int? CommentCount { get; set; }

        public int? LikeCount { get; set; }

        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// ״̬��0��δ��ˣ�1������
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public String CreateUserName { get; set; }

        /// <summary>
        /// ��ͼ1
        /// </summary>
        public String CarryImg1 { get; set; }

        /// <summary>
        /// ��ͼ2
        /// </summary>
        public String CarryImg2 { get; set; }
    }
}
