using assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment02.Data.classes_configration
{
    public class teacherconfiguration : IEntityTypeConfiguration<teacher>
    {
        public void Configure(EntityTypeBuilder<teacher> builder)
        {

            builder.Property(p => p.salary)
               .HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.tchcourse)
                       .WithMany(s => s.crsteacher)
                       .HasForeignKey(p => p.courseid)
                       .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
