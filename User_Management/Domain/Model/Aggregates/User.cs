using backend.User_Management.Domain.Model.Commands;

namespace backend.User_Management.Domain.Model.Aggregates;

public class User
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
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string TypeUser { get; private set; }
    public TimeSpan MaxDailyReservationHour { get; private set; }
    public string IdentificationUser { get; private set; }

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