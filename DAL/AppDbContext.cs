using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TASK_9.Models;

namespace TASK_9.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserNote>()
                .HasOne(n => n.AppUser)
                .WithMany(u => u.UserNotes)
                .HasForeignKey(n => n.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            var passwordHasher = new PasswordHasher<AppUser>();
            var adminUser = new AppUser
            {
                Id = 1,
                Email = "admin@gmail.com",
                Role = "Admin",
                CreatedAt = DateTime.UtcNow
            };

            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin$Secret$123");
            modelBuilder.Entity<AppUser>().HasData(adminUser);
        }
    }
}
