namespace backend.Payment.Interfaces.REST.Resources;

public record CreatePaymentResource(DateTime payMoment, float price, int paymentInformationId, int userId);

