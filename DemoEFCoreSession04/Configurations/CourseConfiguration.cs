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
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            // Seeding بيانات الكورسات
            builder.HasData(
                new Course { Id = 1, Name = "C# & EF Core" },
                new Course { Id = 2, Name = "ASP.NET Core Web API" },
                new Course { Id = 3, Name = "Angular Fundamentals" }
            );
        }
    }
}
