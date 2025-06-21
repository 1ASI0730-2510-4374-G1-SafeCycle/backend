using backend.IAM.Domain.Repositories;
using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Commands;
using backend.Payment.Domain.Repositories;
using backend.Payment.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Payment.Application.Internal.CommandServices;

public class PaymentInformationCommandService(IPaymentInformationRepository paymentInformationRepository, IUserRepository userRepository, IUnitOfWork unitOfWork): IPaymentInformationCommandService
{
     public async Task<PaymentInformation?> Handle(CreatePaymentInformationCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.userId);
        if (user == null) throw new Exception("User Not Found");
        var paymentInformation = new PaymentInformation(command)
        {
            user = user
        };
        try
        {
            await paymentInformationRepository.AddAsync(paymentInformation);
            await unitOfWork.CompleteAsync();
            return paymentInformation;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<PaymentInformation?> Handle(UpdatePaymentInformationCommand command)
    {
        var paymentInformation = await paymentInformationRepository.FindByIdAsync(command.Id);
        
        paymentInformation?.UpdateFromCommand(command);
        
        await unitOfWork.CompleteAsync();
        return paymentInformation;
    }
}