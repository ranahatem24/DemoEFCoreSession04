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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

            // Seeding بيانات الطلاب
            builder.HasData(
                new Student { Id = 1, Name = "Mohamed Hassan" },
                new Student { Id = 2, Name = "Aya Mahmoud" }
            );
        }
    }
}
