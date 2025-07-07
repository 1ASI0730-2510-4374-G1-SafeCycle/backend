namespace backend.Payments.Interfaces.REST.Resources;

public record UpdatePaymentInformationResource( int Id, string cardNumber, string type, string holder, double amount, int userId);