using backend.Payments.Domain.Model.Commands;

namespace backend.Payments.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payments.Domain.Model.Aggregates.Payment?> Handle(CreatePaymentCommand command);
}