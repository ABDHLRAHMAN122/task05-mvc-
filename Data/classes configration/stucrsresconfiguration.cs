using System.Reflection.Emit;
using assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment02.Data.classes_configration
{
    public class stucrsresconfiguration : IEntityTypeConfiguration<stucrsres>
    {
        public void Configure(EntityTypeBuilder<stucrsres> builder)
        {
            
            builder.HasKey(scr => new { scr.StudentId, scr.CourseId });

          
        }
    }
}
