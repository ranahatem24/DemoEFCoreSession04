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
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(e => e.Salary)
                   .HasColumnType("decimal(18,2)");
            // === تغذية البيانات الثابتة (Seeding) ===
            builder.HasData(
                new Employee { Id = 1, Name = "Ahmed Ali", Salary = 8000m, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Sara Mohamed", Salary = 7500m, DepartmentId = 2 }
            );
        }
    }
}
