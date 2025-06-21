using backend.Payments.Domain.Model.Commands;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.Payments.Domain.Services;

public interface IPaymentInformationCommandService
{
    Task<PaymentInformation?> Handle(CreatePaymentInformationCommand command);
    
    Task<PaymentInformation?> Handle(UpdatePaymentInformationCommand command);
}