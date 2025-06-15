namespace backend.Payment.Interfaces.REST.Resources;

public record PaymentInformationResource(int id, int cardNumber, string type, string holder, double amount, int userId);

