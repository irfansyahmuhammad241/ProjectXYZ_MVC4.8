using ProjectXYZ_MVC4._8.Models;
using System.Data.Entity;
using System.Reflection.Emit;

namespace ProjectXYZ_MVC4._8.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // entitas unique
            modelBuilder.Entity<User>()
                      .HasIndex(u => new
                      {
                          u.ID,
                      }).IsUnique();

            modelBuilder.Entity<Company>()
                     .HasIndex(u => new
                     {
                         u.ID
                     }).IsUnique();

            modelBuilder.Entity<Manager>()
                       .HasIndex(u => new
                       {
                           u.ID,
                       }).IsUnique();

            modelBuilder.Entity<Vendor>()
                       .HasIndex(u => new
                       {
                           u.VendorID
                       }).IsUnique();


            modelBuilder.Entity<Project>()
                        .HasIndex(u => new
                        {
                            u.ProjectID
                        }).IsUnique();

            // Create Relation
            modelBuilder.Entity<User>()
               .HasOptional(user => user.Company)
               .WithOptionalPrincipal(company => company.User)
               .Map(p => p.MapKey("CompanyID"));

            // User - ManagerLogistics
            modelBuilder.Entity<User>()
                .HasOptional(user => user.Manager)
                .WithOptionalPrincipal(manager => manager.User)
                .Map(p => p.MapKey("ManagerID"));

            // User - Vendor (One to One)
            modelBuilder.Entity<Vendor>()
                .HasOptional(vendor => vendor.User)
                .WithOptionalPrincipal(user => user.Vendor)
                .Map(p => p.MapKey("UserID"));

            // Vendor - Project (One To Many)
            modelBuilder.Entity<Project>()
                .HasRequired(project => project.Vendor)
                .WithMany(vendor => vendor.Projects)
                .HasForeignKey(project => project.VendorID);

        }

    }

}
