using backend.IAM.Interfaces.REST.Transform;
using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public static class PaymentInformationResourceFromEntityAssembler
{
    public static PaymentInformationResource ToResourceFromEntity(PaymentInformation paymentInformation)
    {
        return new PaymentInformationResource(
                paymentInformation.id,
                paymentInformation.cardNumber,
                paymentInformation.type,
                paymentInformation.holder,
                paymentInformation.amount,
                paymentInformation.user != null
                    ? UserResourceFromEntityAssembler.ToResourceFromEntity(paymentInformation.user)
                    : null
                
            );
    }
}