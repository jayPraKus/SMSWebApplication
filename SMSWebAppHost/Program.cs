using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Core.Repositories;
using SMS.WebApp.Services.IServices;
using SMS.WebApp.Services.Services;
using SMSWebAppData;

namespace SMSWebAppHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Get Connection string; using ternary operator 
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String 'Default connection' not found.");
            builder.Services.AddDbContext<SMSDbContext>(Options => Options.UseSqlServer(connectionString));
            //Use user and roles for tokens
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SMSDbContext>().AddDefaultTokenProviders();
            builder.Services.AddTransient<IAccountServices, AccountServices>();
            builder.Services.AddTransient<IAccountRepositories, AccountRepositories>();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}