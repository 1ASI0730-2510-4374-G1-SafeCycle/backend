namespace backend.Payments.Domain.Model.Commands;

public record CreatePaymentInformationCommand(string cardNumber, string type,  string holder,  double amount, int userId);
