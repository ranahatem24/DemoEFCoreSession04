using C48_EFCore_Session_04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.DbContexts
{
    internal class AppDbContext:DbContext
    {
        // تعريف الـ DbSets الخاصة بجداولك هنا (مثلاً الموظفين والأقسام)
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CompanyDbC48;Trusted_Connection=True;TrustServerCertificate=True;")
                   .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تطبيق الإعدادات (Configurations) تلقائياً من الـ Assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
