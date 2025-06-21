using backend.IAM.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Resources;

public record PaymentInformationResource(int id, int cardNumber, string type, string holder, double amount, UserResource? userId);

