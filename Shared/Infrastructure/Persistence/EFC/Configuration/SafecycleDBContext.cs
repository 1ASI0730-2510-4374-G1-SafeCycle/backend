using backend.Bike_Management.Domain.Model.Aggregates;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.User_Management.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class SafecycleDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<BikeStations> BikeStations { get; set; }
    public SafecycleDBContext(DbContextOptions<SafecycleDBContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // add builder entities
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(x => x.Username).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.TypeUser).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.MaxDailyReservationHour).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.IdentificationUser).IsRequired();
        
        modelBuilder.Entity<BikeStations>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.address).IsRequired();
            entity.Property(e => e.maxCapacity).IsRequired();
            entity.Property(e => e.lat).IsRequired();
            entity.Property(e => e.lng).IsRequired();
        });
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}