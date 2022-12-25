using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        private IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperations { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(x =>
            {
                x.ToTable("Brands").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name).HasColumnName("Name");
                x.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(x =>
            {
                x.ToTable("Models").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.BrandId).HasColumnName("BrandId");
                x.Property(p => p.Name).HasColumnName("Name");
                x.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                x.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                x.HasOne(p => p.Brand);
            });

            Brand[] brandsSeetData = { new(1, "BMW"), new(2, "Mercedes") };
            modelBuilder.Entity<Brand>().HasData(brandsSeetData);

            Model[] modelsSeetData = { new(1,1,"Series 4", 1500, ""), new(2, 1, "Series 3", 1200, ""),
                new(3, 2, "A180", 1800, "") };
            modelBuilder.Entity<Model>().HasData(modelsSeetData);
        }
    }
}