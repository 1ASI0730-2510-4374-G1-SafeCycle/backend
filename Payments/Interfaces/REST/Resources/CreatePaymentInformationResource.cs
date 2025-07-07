namespace backend.Payments.Interfaces.REST.Resources;

public record CreatePaymentInformationResource(string cardNumber, string type, string holder, double amount, int userId);

