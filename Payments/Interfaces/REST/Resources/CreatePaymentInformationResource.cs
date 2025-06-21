namespace backend.Payments.Interfaces.REST.Resources;

public record CreatePaymentInformationResource(int cardNumber, string type, string holder, double amount, int userId);

