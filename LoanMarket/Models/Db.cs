namespace LoanMarket.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<LoanMarketComment> LoanMarketComment { get; set; }
        public virtual DbSet<LoanMarketForum> LoanMarketForum { get; set; }
        public virtual DbSet<LoanMarketGroup> LoanMarketGroup { get; set; }
        public virtual DbSet<LoanMarketProduct> LoanMarketProduct { get; set; }
        public virtual DbSet<LoanMarketProductType> LoanMarketProductType { get; set; }
        public virtual DbSet<LoanMarketSpread> LoanMarketSpread { get; set; }
        public virtual DbSet<LoanMarketSpreadBill> LoanMarketSpreadBill { get; set; }
        public virtual DbSet<LoanMarketUser> LoanMarketUser { get; set; }
        public virtual DbSet<LoanMarketUserGroup> LoanMarketUserGroup { get; set; }
        public virtual DbSet<LoanMarketUserInfo> LoanMarketUserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanMarketForum>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<LoanMarketSpreadBill>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);
        }
    }
}
