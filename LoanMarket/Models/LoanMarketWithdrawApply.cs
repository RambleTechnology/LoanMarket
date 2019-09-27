namespace LoanMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanMarketWithdrawApply")]
    public partial class LoanMarketWithdrawApply
    {
        [StringLength(100)]
        public string Id { get; set; }

        public int UserNo { get; set; }

        /// <summary>
        /// �������ܽ��
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// �����������ֽ��
        /// </summary>
        public decimal ApplyWithwrawAmount { get; set; }

        public string UserNickName { get; set; }

        public string UserRealName { get; set; }

        public string ZFBAccount { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// ״̬���ύ���룻���ͨ�������ʧ�ܣ�
        /// </summary>
        public string Status { get; set; }


        [StringLength(100)]
        public string SpareField1 { get; set; }





    }
}
