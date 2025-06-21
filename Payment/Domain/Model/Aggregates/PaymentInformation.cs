using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.IAM.Domain.Model.Aggregates;
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
    
    public int id { get;  set; }
    
    [Required]
    [Range(1, 1000)]
    public int cardNumber { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string type { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string holder { get; set; }
    
    [Required]
    [Range(1, 1000)]
    public double amount { get; set; }
    [Required]
    public int userId { get; set; }
    
    [Required]
    [ForeignKey("userId")]
    public required User user { get; set; }
    public ICollection<Payments> Payments { get; set; } = new List<Payments>();
    
    public void UpdateFromCommand(UpdatePaymentInformationCommand command)
    {
        cardNumber = command.cardNumber;
        type = command.type;
        holder = command.holder;
        amount = command.amount;
        userId = command.userId;
    }
}
