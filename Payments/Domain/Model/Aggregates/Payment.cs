using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Payments.Domain.Model.Commands;
using backend.Renting.Domain.Model.Aggregates;

namespace backend.Payments.Domain.Model.Aggregates;

public partial class Payment
{
    protected Payment()
    {
        payMoment = DateTime.MinValue;
        price = 0;
        PaymentInformationId = 0;
    }

    public Payment(CreatePaymentCommand command)
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
