namespace backend.Payment.Interfaces.REST.Resources;

public record PaymentResource(int id, DateTime payMoment, float price, int paymentInformationId, int userId);