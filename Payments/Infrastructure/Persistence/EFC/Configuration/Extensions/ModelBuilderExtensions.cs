using backend.Payments.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backend.Payments.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPaymentsConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Model.Aggregates.Payment>(entity =>
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
    }
}