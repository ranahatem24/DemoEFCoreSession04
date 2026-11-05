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
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PName).IsRequired().HasMaxLength(100);

            // Seeding بيانات ثابتة للمشاريع
            builder.HasData(
                new Project { Id = 1, PName = "E-Commerce App" },
                new Project { Id = 2, PName = "Banking System" }
            );
        }
    }
}
