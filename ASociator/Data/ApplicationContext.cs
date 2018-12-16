using ASociator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASociator.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public IConfiguration Configuration { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration config)
            : base(options)
        {
            Configuration = config;
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = Configuration["admin_email"];
            string adminPassword = Configuration["admin_password"];

            // добавляем роли
            UserRole adminRole = new UserRole { Id = 1, Name = adminRoleName };
            UserRole userRole = new UserRole { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
