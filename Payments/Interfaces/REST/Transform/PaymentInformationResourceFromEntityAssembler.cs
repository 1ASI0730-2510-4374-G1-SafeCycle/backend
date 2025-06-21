using backend.IAM.Interfaces.REST.Transform;
using backend.Payments.Interfaces.REST.Resources;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

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