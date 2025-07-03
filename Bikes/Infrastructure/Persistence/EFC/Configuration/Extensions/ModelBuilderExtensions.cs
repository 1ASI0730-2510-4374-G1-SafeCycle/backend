using backend.Bikes.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backend.Bikes.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyBikesConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BikeStations>(entity =>
        {
            entity.HasKey(e => e.Id);
    
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.address).IsRequired();
            entity.Property(e => e.maxCapacity).IsRequired();
            entity.OwnsOne(e => e.Location, loc =>
            {
                loc.Property(l => l.Latitude).HasColumnName("Latitude").IsRequired();
                loc.Property(l => l.Longitude).HasColumnName("Longitude").IsRequired();

                loc.WithOwner().HasForeignKey("Id");
                loc.HasKey("Id");
            });
        });
        modelBuilder.Entity<Bike>(entity =>
        {
            entity.HasKey(y => y.Id);
            entity.Property(y => y.Id).ValueGeneratedOnAdd();

            entity.Property(y => y.condition).IsRequired();
            entity.Property(y => y.available).IsRequired();

            entity.HasOne(b => b.bikeStation)
                .WithMany(bs => bs.Bike)
                .IsRequired();

        });
    }
}