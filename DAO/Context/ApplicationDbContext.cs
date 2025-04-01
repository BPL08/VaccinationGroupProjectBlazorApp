using Microsoft.EntityFrameworkCore;
using BO.Entity;
namespace DAO.Context
{
  
    public class ApplicationDbContext : DbContext
    {
        // Constructor with options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        
        public DbSet<VaccineCenter> VaccineCenters { get; set; }
        public DbSet<VaccineBatch> VaccineBatches { get; set; }
        public DbSet<VaccineCategory> VaccineCategories { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccinePackage> VaccinePackages { get; set; }
        public DbSet<VaccinePackageDetail> VaccinePackageDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ChildrenProfile> ChildrenProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; } 
        public DbSet<VaccineHistory> VaccineHistories { get; set; }
        public DbSet<VaccinationSchedule> VaccinationSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=VaccineScheduleSystem;User Id=sa;Password=12345;TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccineCategory>()
                .HasOne(v => v.ParentCategory)
                .WithMany()
                .HasForeignKey(v => v.FKParentCategoryId);


            modelBuilder.Entity<VaccineBatch>()
                .HasOne(vb => vb.Center)
                .WithMany()
                .HasForeignKey(vb => vb.FKCenterId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Vaccine>()
                .HasOne(v => v.Category)
                .WithMany()
                .HasForeignKey(v => v.FKCategoryId);

            modelBuilder.Entity<Vaccine>()
                .HasOne(v => v.Batch)
                .WithMany()
                .HasForeignKey(v => v.FKBatchId);

            modelBuilder.Entity<VaccinePackageDetail>()
                .HasOne(vpd => vpd.Vaccine)
                .WithMany()
                .HasForeignKey(vpd => vpd.FKVaccineId);

            modelBuilder.Entity<VaccinePackageDetail>()
                .HasOne(vpd => vpd.VaccinePackage)
                .WithMany()
                .HasForeignKey(vpd => vpd.FKVaccinePackageId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Center)
                .WithMany()
                .HasForeignKey(a => a.FKCenterId);

            modelBuilder.Entity<ChildrenProfile>()
                .HasOne(cp => cp.Account)
                .WithMany()
                .HasForeignKey(cp => cp.FKAccountId);


            modelBuilder.Entity<Order>()
                .HasOne(o => o.Profile)
                .WithMany()
                .HasForeignKey(o => o.FKProfileId);




            modelBuilder.Entity<OrderDetail>()
                 .HasOne(od => od.Order)
                 .WithMany()
                 .HasForeignKey(od => od.FKOrderId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Vaccine)
                .WithMany()
                .HasForeignKey(od => od.FKVaccineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.VaccinePackage)
                .WithMany()
                .HasForeignKey(od => od.FKVaccinePackageId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Vaccine)
                .WithMany()
                .HasForeignKey(vh => vh.FKVaccineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Profile)
                .WithMany()
                .HasForeignKey(vh => vh.FKProfileId)
                .OnDelete(DeleteBehavior.Restrict);

        

            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Center)
                .WithMany()
                .HasForeignKey(vh => vh.FKCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.Profile)
                .WithMany()
                .HasForeignKey(vs => vs.FKProfileId);

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.Center)
                .WithMany()
                .HasForeignKey(vs => vs.FKCenterId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.OrderDetail)
                .WithMany()
                .HasForeignKey(vs => vs.FKOrderDetailsId)
                .OnDelete(DeleteBehavior.Restrict);

          

        }
     
    }
}
