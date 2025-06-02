namespace backend.User_Management.Domain.Model.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string TypeUser { get; set; }
    public TimeSpan MaxDailyReservationHour { get; set; }
    public string IdentificationUser { get; set; }
}