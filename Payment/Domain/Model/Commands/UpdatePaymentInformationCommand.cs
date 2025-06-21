namespace backend.Payment.Domain.Model.Commands;

public record UpdatePaymentInformationCommand(
    int Id,
    int cardNumber,
    string type,
    string holder,
    double amount,
    int userId);


