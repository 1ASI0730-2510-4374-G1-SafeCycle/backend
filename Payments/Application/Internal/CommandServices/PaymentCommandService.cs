using backend.Payments.Domain.Model.Commands;
using backend.Payments.Domain.Repositories;
using backend.Payments.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Payments.Application.Internal.CommandServices;

public class PaymentCommandService (IPaymentRepository paymentRepository, IPaymentInformationRepository paymentInformationRepository, IUnitOfWork unitOfWork) : IPaymentCommandService
{
    public async Task<Payments.Domain.Model.Aggregates.Payment?> Handle(CreatePaymentCommand command)
    {
        var paymentInformation = await paymentInformationRepository.FindByIdAsync(command.paymentInformationId);
        if (paymentInformation == null) throw new Exception("Payment Information not found");
        
        var payment = new Payments.Domain.Model.Aggregates.Payment(command)
        {
            paymentInformation = paymentInformation
        };
        
        try
        {
            await paymentRepository.AddAsync(payment);
            await unitOfWork.CompleteAsync();
            return payment;
        }
        catch (Exception)
        {
            return null;
        }
    }
}