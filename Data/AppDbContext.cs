using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                "Server=sql.ects;Database=UsersDb_Eremeev;User Id=student_06;Password=student_06;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer(
            //    "Server=sql.ects;Database=UsersDb_Eremeev;User Id=student_06;Password=student_06;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer(
            //   "Server=localhost;Database=UsersDb_Eremeev;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>() 
            .HasOne(s => s.Userprofile)
            .WithOne(ps => ps.User)
            .HasForeignKey<UserProfile>(ps => ps.Id);

            modelBuilder.Entity <Role>() 
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.Role_Id);

        }
    }
}
