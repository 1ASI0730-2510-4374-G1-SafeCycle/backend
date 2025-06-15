using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payments payments) =>
        new PaymentResource(payments.id, payments.payMoment, payments.price, payments.paymentInformationId,
            payments.userId);
}