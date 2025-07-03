using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Tours.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyToursConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.hour)
                .HasMaxLength(500);

            entity.Property(e => e.img)
                .IsRequired();

            entity.Property(e => e.price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        });
        
        modelBuilder.Entity<TourBooking>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.rent)
                .WithMany(bs => bs.TourBookings)
                .IsRequired();
            entity.HasOne(e => e.tour)
                .WithMany(bs => bs.TourBookings)
                .IsRequired();
        });
    }
}