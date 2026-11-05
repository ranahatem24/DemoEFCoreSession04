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
    internal class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            // 1. تحديد الـ Composite Primary Key (المفتاح الأساسي المركب)
            builder.HasKey(cs => new { cs.CourseId, cs.StudentId });

            // 2. إعداد العلاقات
            builder.HasOne(cs => cs.Course)
                   .WithMany(c => c.CourseStudents)
                   .HasForeignKey(cs => cs.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cs => cs.Student)
                   .WithMany(s => s.CourseStudents)
                   .HasForeignKey(cs => cs.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 3. Seeding العلاقات الثابتة (أي طالب مسجل في أي كورس)
            builder.HasData(
                new CourseStudent { CourseId = 1, StudentId = 1 }, // Mohamed -> C#
                new CourseStudent { CourseId = 2, StudentId = 1 }, // Mohamed -> Web API
                new CourseStudent { CourseId = 1, StudentId = 2 }  // Aya -> C#
            );
        }
    }
}
