using assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment02.Data.classes_configration
{
    public class courseconfiguration : IEntityTypeConfiguration<course>
    {

       

        public void Configure(EntityTypeBuilder<course> builder)
        {


            builder.Property(scr => scr.Name)
                   .HasMaxLength(50);

            builder.HasMany(d => d.crstudent)
                       .WithOne(s => s.crsid)
                       .HasForeignKey(p => p.CourseId)
                       .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
