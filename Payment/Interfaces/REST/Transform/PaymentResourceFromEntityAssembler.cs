using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payments payment)
    {
        return new PaymentResource(
            payment.id,
            payment.payMoment,
            payment.price,
            payment.paymentInformation != null
                ? PaymentInformationResourceFromEntityAssembler.ToResourceFromEntity(payment.paymentInformation)
                : null
        );
    }
}