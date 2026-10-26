using assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment02.Data.classes_configration
{
    public class Departmentconfiguration : IEntityTypeConfiguration<Department>
    {
        

        public void Configure(EntityTypeBuilder<Department> builder)
        {


            builder.Property(scr => scr.Name)
                   .HasMaxLength(50);

            builder.HasMany(d => d.courses)
                       .WithOne(s => s.crsdept)
                       .HasForeignKey(p => p.deptid)
                       .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.teachrs)
                  .WithOne(s => s.tchdept)
                  .HasForeignKey(p => p.deptid)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.students)
                  .WithOne(s => s.studept)
                  .HasForeignKey(p => p.deptid)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
