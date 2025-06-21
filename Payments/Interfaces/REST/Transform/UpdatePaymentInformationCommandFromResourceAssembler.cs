using backend.Payments.Domain.Model.Commands;
using backend.Payments.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public static class UpdatePaymentInformationCommandFromResourceAssembler
{
    public static UpdatePaymentInformationCommand ToCommandFromResource(this UpdatePaymentInformationResource resource)
    {
        return new UpdatePaymentInformationCommand(resource.Id, resource.cardNumber, resource.type, resource.holder,
            resource.amount, resource.userId); 
    }
}