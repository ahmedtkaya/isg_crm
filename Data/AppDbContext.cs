using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using isg_crm.Models;

namespace isg_crm.Data
{
    //her migrationsda managers ve company tablosu verileri siliniyor!!
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Ohs_Employee> Ohs_Employees { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Assignees> Assignees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the relationship for OfferedTalents
            modelBuilder.Entity<Manager>()
                .HasIndex(u => u.Email)
                .IsUnique();  // Email alanı benzersiz olacak
            modelBuilder.Entity<Ohs_Employee>()
            .HasIndex(u => u.Email)
            .IsUnique();
            modelBuilder.Entity<Company>()
            .HasIndex(u => u.CompanyEmail)
            .IsUnique();

            modelBuilder.Entity<Manager>().HasData(
            new Manager
            {
                Id = Guid.NewGuid(),
                Uuid = Guid.NewGuid(),
                Email = "admin@isg.com",
                Type = ManagerType.Admin,
                Name = "Sistem Admini",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        }
    }
}