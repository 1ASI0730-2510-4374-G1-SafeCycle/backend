namespace backend.Payment.Interfaces.REST.Resources;

public record UpdatePaymentInformationResource( int Id, int cardNumber, string type, string holder, double amount, int userId);