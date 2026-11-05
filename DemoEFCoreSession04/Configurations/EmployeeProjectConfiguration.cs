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
    internal class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            // تحديد مفتاح أساسي مركب (Composite Primary Key)
            builder.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            builder.HasOne(ep => ep.Employee)
                   .WithMany(e => e.EmployeeProjects)
                   .HasForeignKey(ep => ep.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ep => ep.Project)
                   .WithMany(p => p.EmployeeProjects)
                   .HasForeignKey(ep => ep.ProjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seeding العلاقات الثابتة في جدول الربط (أي موظف يعمل في أي مشروع)
            builder.HasData(
                new EmployeeProject { EmployeeId = 1, ProjectId = 1 },
                new EmployeeProject { EmployeeId = 1, ProjectId = 2 },
                new EmployeeProject { EmployeeId = 2, ProjectId = 1 }
            );
        }
    }
}
