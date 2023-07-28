using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSWebAppData.Models.DataModels;

namespace SMSWebAppData
{
    public class SMSDbContext:IdentityDbContext
    {
        //Below method will automatically configure connection string throughout the project
        //DBContextOption has all the options of creating database,storedProcedure, congiguring the database
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}