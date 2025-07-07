namespace backend.Payments.Domain.Model.Commands;

public record UpdatePaymentInformationCommand(
    int Id,
    string cardNumber,
    string type,
    string holder,
    double amount,
    int userId);


