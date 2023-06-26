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
        public DbSet<Students> Students { get; set; }

    }
}