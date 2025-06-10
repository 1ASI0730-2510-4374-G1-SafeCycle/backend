using backend.Renting.Domain.Model.Aggregates;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.User_Management.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class SafecycleDBContext : DbContext
{
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
        
        modelBuilder.Entity<Rent>().HasKey(x => x.Id);
        modelBuilder.Entity<Rent>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Rent>().Property(x => x.StartTime).IsRequired();
        modelBuilder.Entity<Rent>().Property(x => x.EndTime).IsRequired();
        modelBuilder.Entity<Rent>().Property(x => x.PaymentId).IsRequired();
        modelBuilder.Entity<Rent>().Property(x => x.UserId).IsRequired();
        modelBuilder.Entity<Rent>().Property(x => x.BikeStationStartId).IsRequired();
        modelBuilder.Entity<Rent>().Property(x => x.BikeStationEndId).IsRequired();
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}