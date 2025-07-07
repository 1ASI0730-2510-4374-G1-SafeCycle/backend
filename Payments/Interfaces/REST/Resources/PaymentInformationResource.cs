using backend.IAM.Interfaces.REST.Resources;

namespace backend.Payments.Interfaces.REST.Resources;

public record PaymentInformationResource(int id, string cardNumber, string type, string holder, double amount, UserResource? userId);

