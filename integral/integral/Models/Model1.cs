namespace integral.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Integral_History> Integral_History { get; set; }
        public virtual DbSet<Integral_Main> Integral_Main { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Integral_History>()
                .Property(e => e.Integral)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Integral_Main>()
                .Property(e => e.Integral)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Psd)
                .IsFixedLength();
        }
    }
}
