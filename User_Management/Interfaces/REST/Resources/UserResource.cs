namespace backend.User_Management.Interfaces.REST.Resources;

public record UserResource(string Username, 
    string Email,
    string Password, 
    string TypeUser, 
    string MaxDailyReservationHour, 
    string IdentificationUser );