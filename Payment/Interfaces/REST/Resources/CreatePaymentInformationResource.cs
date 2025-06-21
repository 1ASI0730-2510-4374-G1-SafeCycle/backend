namespace backend.Payment.Interfaces.REST.Resources;

public record CreatePaymentInformationResource(int cardNumber, string type, string holder, double amount, int userId);

