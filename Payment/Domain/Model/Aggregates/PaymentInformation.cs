using System.ComponentModel.DataAnnotations;
using backend.Payment.Domain.Model.Commands;

namespace backend.Payment.Domain.Model.Aggregates;

public partial class PaymentInformation
{
    protected PaymentInformation()
    {
        cardNumber = 0;
        type = string.Empty;
        holder = string.Empty;
        amount = 0;
        userId = -1;
    }

    public PaymentInformation(CreatePaymentInformationCommand command)
    {
        cardNumber = command.cardNumber;
        type = command.type;
        holder = command.holder;
        amount = command.amount;
        userId = command.userId;
    }
    
    public int id { get; private set; }
    
    [Required]
    [Range(1, 1000)]
    public int cardNumber { get; private set; }
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string type { get; private set; }
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string holder { get; private set; }

    [Range(1, 1000)]
    public double amount { get; private set; }
    public int userId { get; private set; }
}
