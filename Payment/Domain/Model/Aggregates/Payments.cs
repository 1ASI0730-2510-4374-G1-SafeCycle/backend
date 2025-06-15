using System.ComponentModel.DataAnnotations;
using backend.Payment.Domain.Model.Commands;

namespace backend.Payment.Domain.Model.Aggregates;

public partial class Payments
{
    protected Payments()
    {
        payMoment = DateTime.MinValue;
        price = 0;
        paymentInformationId = -1;
        userId = -1;
    }

    public Payments(CreatePaymentCommand command)
    {
        payMoment = command.payMoment;
        price = command.price;
        paymentInformationId = command.paymentInformationId;
        userId = command.userId;
    }
    

    
    public int id { get; private set; }
    
    [Required]
    public DateTime payMoment { get; private set; }
    [Range(1, 1000)]
    public float price { get; private set; }
    public int paymentInformationId { get; private set; }
    public int userId { get; private set; }
        
        
}
