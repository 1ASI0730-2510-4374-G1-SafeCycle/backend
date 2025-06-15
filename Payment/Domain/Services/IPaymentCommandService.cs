using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Commands;

namespace backend.Payment.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payments?> Handle(CreatePaymentCommand command);
}