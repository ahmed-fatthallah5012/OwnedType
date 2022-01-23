using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    public class SystemContext : DbContext
    {
        public SystemContext()
        {

        }
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            optionsBuilder.UseSqlServer("Server=.;Database=SysDb;User Id=sa;Password=Thank$123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(ent =>
            {
                ent.Property(a=>a.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<Journal>(ent =>
            {
                ent.ToTable("Journal");
                ent.Property(a=>a.Id).ValueGeneratedNever();
                ent.OwnsOne(a=>a.BrandA , x =>
                {
                    x.Property<Guid>("JournalId");
                    x.HasKey("JournalId");
                    x.Property(a=>a.BrandId).HasColumnName("BrandA.BrandId");
                    x.ToTable("Journal");
                    x.HasOne(a=>a.Brand)
                    .WithMany()
                    .HasForeignKey(a=>a.BrandId)
                    .HasConstraintName("FK_BrandA_Journal_Brand.xD");
                    x.WithOwner().HasForeignKey("JournalId");
                    x.Navigation(a=>a.Brand);
                });
                ent.OwnsOne(a => a.BrandB, x =>
                {

                    x.Property<Guid>("JournalId");
                    x.HasKey("JournalId");
                    x.Property(a => a.BrandId).HasColumnName("BrandB.BrandId");
                    x.ToTable("Journal");
                    x.HasOne(a => a.Brand)
                    .WithMany()
                    .HasForeignKey(a => a.BrandId)
                    .HasConstraintName("FK_BrandB_Journal_Brand.xD");
                    x.WithOwner().HasForeignKey("JournalId");
                    x.Navigation(a => a.Brand);
                });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
