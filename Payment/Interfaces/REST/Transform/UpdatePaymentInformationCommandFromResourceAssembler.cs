using backend.Payment.Domain.Model.Commands;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public static class UpdatePaymentInformationCommandFromResourceAssembler
{
    public static UpdatePaymentInformationCommand ToCommandFromResource(this UpdatePaymentInformationResource resource)
    {
        return new UpdatePaymentInformationCommand(resource.Id, resource.cardNumber, resource.type, resource.holder,
            resource.amount, resource.userId); 
    }
}