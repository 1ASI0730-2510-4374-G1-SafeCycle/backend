namespace backend.Payments.Domain.Model.Commands;

public record CreatePaymentInformationCommand(int cardNumber, string type,  string holder,  double amount, int userId);
