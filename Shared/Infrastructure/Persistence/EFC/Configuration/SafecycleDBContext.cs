using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.Payments.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Entities;
using backend.Tours.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class SafecycleDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<BikeStations> BikeStations { get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Payments.Domain.Model.Aggregates.Payment> Payments { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<PaymentInformation> PaymentInformation { get; set; }
    public DbSet<TourBooking> TourBookings { get; set; }
    public SafecycleDBContext(DbContextOptions<SafecycleDBContext> options) : base(options){}
    
    private readonly TimestampAudit _timestampsAudit;

    public SafecycleDBContext(DbContextOptions<SafecycleDBContext> options, TimestampAudit timestampsAudit)
        : base(options)
    {
        _timestampsAudit = timestampsAudit;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_timestampsAudit);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // add builder entities
        
        modelBuilder.ApplyIamConfiguration();
        
        modelBuilder.ApplyRentingConfiguration();
        
        modelBuilder.ApplyBikesConfiguration();
        
        modelBuilder.ApplyToursConfiguration();

        
        modelBuilder.ApplyPaymentsConfiguration();
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}