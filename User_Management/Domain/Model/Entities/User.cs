namespace backend.User_Management.Domain.Model.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string TypeUser { get; private set; }
    public TimeSpan MaxDailyReservationHour { get; private set; }
    public string IdentificationUser { get; private set; }
}