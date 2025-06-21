namespace backend.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(DateTime payMoment, float price, int paymentInformationId);

