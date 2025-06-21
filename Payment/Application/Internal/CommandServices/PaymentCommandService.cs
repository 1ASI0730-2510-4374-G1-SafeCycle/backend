using backend.IAM.Domain.Repositories;
using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Commands;
using backend.Payment.Domain.Repositories;
using backend.Payment.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Payment.Application.Internal.CommandServices;

public class PaymentCommandService (IPaymentRepository paymentRepository, IPaymentInformationRepository paymentInformationRepository, IUnitOfWork unitOfWork) : IPaymentCommandService
{
    public async Task<Payments?> Handle(CreatePaymentCommand command)
    {
        var paymentInformation = await paymentInformationRepository.FindByIdAsync(command.paymentInformationId);
        if (paymentInformation == null) throw new Exception("Payment Information not found");
        
        var payment = new Payments(command)
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