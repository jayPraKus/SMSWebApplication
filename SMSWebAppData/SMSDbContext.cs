using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SMSWebAppData
{
    public class SMSDbContext:IdentityDbContext
    {
        //Below method will automatically configure connection string throughout the project
        //DBContextOption has all the options of creating database,storedProcedure, congiguring the database
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options) 
        {

        }
    }
}