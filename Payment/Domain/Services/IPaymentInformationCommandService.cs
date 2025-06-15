using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Commands;

namespace backend.Payment.Domain.Services;

public interface IPaymentInformationCommandService
{
    Task<PaymentInformation?> Handle(CreatePaymentInformationCommand command);
    
    Task<PaymentInformation?> Handle(UpdatePaymentInformationCommand command);
}