using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public static class PaymentInformationResourceFromEntityAssembler
{
    public static PaymentInformationResource ToResourceFromEntity(PaymentInformation paymentInformation)=>
    new PaymentInformationResource(paymentInformation.id, paymentInformation.cardNumber, paymentInformation.type, paymentInformation.holder, paymentInformation.amount, paymentInformation.userId);
}