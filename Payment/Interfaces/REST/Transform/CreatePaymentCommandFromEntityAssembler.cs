using backend.Payment.Domain.Model.Commands;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public static class CreatePaymentCommandFromEntityAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(this CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(resource.payMoment, resource.price, resource.paymentInformationId, resource.userId);
    }
}