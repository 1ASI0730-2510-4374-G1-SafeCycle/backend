namespace backend.IAM.Interfaces.REST.Resources;

public record CreateUserResource(string Username, 
    string Email,
    string Password, 
    string TypeUser, 
    TimeSpan MaxDailyReservationHour, 
    string IdentificationUser );