using System.ComponentModel.DataAnnotations;
using backend.IAM.Domain.Model.Commands;
using backend.Renting.Domain.Model.Aggregates;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.IAM.Domain.Model.Aggregates;

public partial class User
{
    public User(CreateUserCommand command)
    {
        Username = command.Username;
        Email = command.Email;
        Password = command.Password;
        TypeUser = command.TypeUser;
        MaxDailyReservationHour = command.MaxDailyReservationHour;
        IdentificationUser = command.IdentificationUser;
    }
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Username { get; private set; }
    [Required]
    [StringLength(50)]
    public string Email { get; private set; }
    [Required]
    [StringLength(50)]
    public string Password { get; private set; }
    [Required]
    [StringLength(7)]
    public string TypeUser { get; private set; }
    [Required]
    public TimeSpan MaxDailyReservationHour { get; private set; }
    [Required]
    [StringLength(50)]
    public string IdentificationUser { get; private set; }
    
    public ICollection<PaymentInformation> PaymentInformation { get; set; } = new List<PaymentInformation>();
    public ICollection<Rent> Rents { get; set; } = new List<Rent>();
    
    public User()
    {
        this.Username = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
        this.TypeUser = string.Empty;
        this.MaxDailyReservationHour = TimeSpan.Zero;
        this.IdentificationUser = string.Empty;
    }
}