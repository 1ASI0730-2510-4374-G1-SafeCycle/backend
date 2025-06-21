namespace backend.Payments.Interfaces.REST.Resources;

public record PaymentResource(int id, DateTime payMoment, float price, PaymentInformationResource? paymentInformationId);