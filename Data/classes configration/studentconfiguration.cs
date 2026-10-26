using assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment02.Data.classes_configration
{
    public class studentconfiguration : IEntityTypeConfiguration<student>
    {
        public void Configure(EntityTypeBuilder<student> builder)
        {
            


            builder.Property(scr => scr.Name)
                   .HasMaxLength(50);

            builder.HasMany(d => d.stucourse)
                   .WithOne(s => s.stuid)
                   .HasForeignKey(p => p.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

        }        
    }
}
