using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
  internal class BaseDbContext : DbContext
  {
    protected IConfiguration Configuration { get; set; }
    public DbSet<Brand> Brands { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
      //if (!dbContextOptionsBuilder.IsConfigured)
      //  base.OnConfiguring(dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Brand>(brand =>
      {
        brand.ToTable("Brands").HasKey(k => k.Id);
        brand.Property(p=>p.Id).HasColumnName("Id");
        brand.Property(p=>p.Name).HasColumnName("Name");
      });

      Brand[] brandEntitySeeds = new Brand[] { new Brand(1, "BMW"), new Brand(2, "Mercedes") };
      modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);
    }
  }
}
