
using assignment02.Data.classes_configration;
using assignment02.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment02.Data.DigitalDBcontext
{ 
    public class DigitalDBContexts : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Digital;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    }
     

    public DbSet<Department> Departments { get; set; }
    public DbSet<stucrsres> stucrsres { get; set; }
    public DbSet<student> students { get; set; }
    public DbSet<teacher> teachers { get; set; }
    public DbSet<course> courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Departmentconfiguration());
            modelBuilder.ApplyConfiguration(new courseconfiguration());
            modelBuilder.ApplyConfiguration(new studentconfiguration());
            modelBuilder.ApplyConfiguration(new teacherconfiguration());
            modelBuilder.ApplyConfiguration(new stucrsresconfiguration());
    }   

}   }
