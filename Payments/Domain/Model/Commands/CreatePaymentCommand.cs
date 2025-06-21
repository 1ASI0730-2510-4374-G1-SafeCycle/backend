namespace backend.Payments.Domain.Model.Commands;

public record CreatePaymentCommand(DateTime payMoment, float price, int paymentInformationId);
