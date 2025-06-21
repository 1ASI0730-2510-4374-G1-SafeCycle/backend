using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Payment.Domain.Model.Commands;
using backend.Renting.Domain.Model.Aggregates;

namespace backend.Payment.Domain.Model.Aggregates;

public partial class Payments
{
    protected Payments()
    {
        payMoment = DateTime.MinValue;
        price = 0;
        PaymentInformationId = 0;
    }

    public Payments(CreatePaymentCommand command)
    {
        payMoment = command.payMoment;
        price = command.price;
        PaymentInformationId = command.paymentInformationId;
    }
    

    
    public int id { get; set; }
    
    [Required]
    public DateTime payMoment { get;  set; }
    [Range(1, 1000)]
    [Required]
    public float price { get;  set; }
    [Required]
    public int PaymentInformationId { get;  set; }
    
    [ForeignKey("PaymentInformationId")]
    [Required]
    public required PaymentInformation paymentInformation { get; set; }
    

    public ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
