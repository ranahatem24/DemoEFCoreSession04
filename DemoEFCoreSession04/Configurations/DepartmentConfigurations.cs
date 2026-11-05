using C48_EFCore_Session_04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // علاقة واحد لمتعدد بين Department و Employees
            builder.HasMany(d => d.Employees)
                   .WithOne(e => e.Department)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // علاقة أن القسم له مدير واحد (Employee)
            builder.HasOne(d => d.Manager)
                   .WithOne(e => e.ManagedDepartment)
                   .HasForeignKey<Department>(d => d.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === تغذية البيانات الثابتة (Seeding) ===
            builder.HasData(
                new Department { Id = 1, Name = "IT & Software" },
                new Department { Id = 2, Name = "HR & Administration" },
                new Department { Id = 3, Name = "Finance" }
            );
        }
    }
}
