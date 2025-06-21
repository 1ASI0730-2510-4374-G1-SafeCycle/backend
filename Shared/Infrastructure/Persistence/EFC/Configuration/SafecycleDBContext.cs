using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.IAM.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Entities;
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
        modelBuilder.Entity<Rent>().HasOne(x => x.Payment).WithMany(xs => xs.Rents).IsRequired();
        modelBuilder.Entity<Rent>().HasOne(x => x.user).WithMany(xs => xs.Rents).IsRequired().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Rent>().HasOne(x => x.bikeStations).WithMany(xs => xs.Rents).IsRequired();
        
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
        
        modelBuilder.Entity<Payments.Domain.Model.Aggregates.Payment>(entity =>
        {
            entity.HasKey(y => y.id);
            entity.Property(y => y.id).ValueGeneratedOnAdd();
            entity.Property(y => y.payMoment).IsRequired();
            entity.HasOne(y => y.paymentInformation)
                .WithMany(ys => ys.Payments)
                .IsRequired();
        });
        modelBuilder.Entity<PaymentInformation>(entity =>
        {
            entity.HasKey(y => y.id);
            entity.Property(y => y.id).ValueGeneratedOnAdd();
            entity.Property(y => y.amount).IsRequired();
            entity.HasOne(y => y.user)
                .WithMany(ys => ys.PaymentInformation)
                .IsRequired();
            entity.Property(y => y.holder).IsRequired();
            entity.Property(y => y.cardNumber).IsRequired();
            entity.Property(y => y.type).IsRequired();
        });

        modelBuilder.UseSnakeCaseNamingConvention();
    }
}