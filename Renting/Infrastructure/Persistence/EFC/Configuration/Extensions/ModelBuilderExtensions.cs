using backend.Renting.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backend.Renting.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyRentingConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rent>().HasKey(x => x.Id);
        modelBuilder.Entity<Rent>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Rent>().Property(x => x.StartTime).IsRequired();
        modelBuilder.Entity<Rent>().Property(x => x.EndTime).IsRequired();
        modelBuilder.Entity<Rent>().HasOne(x => x.Payment).WithMany(xs => xs.Rents).IsRequired();
        modelBuilder.Entity<Rent>().HasOne(x => x.user).WithMany(xs => xs.Rents).IsRequired().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Rent>().HasOne(x => x.bikeStations).WithMany(xs => xs.Rents).IsRequired();

    }
}