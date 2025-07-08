using backend.Payments.Domain.Model.Commands;
using backend.Payments.Interfaces.REST.Resources;

namespace backend.Payments.Interfaces.REST.Transform;

public static class CreatePaymentInformationCommandFromEntityAssembler
{
    public static CreatePaymentInformationCommand ToCommandFromResource(this CreatePaymentInformationResource resource)
    {
        return new CreatePaymentInformationCommand(
            resource.cardNumber,
            resource.type,  
            resource.holder,
            resource.amount,
            resource.userId
        );
    }
}