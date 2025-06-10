namespace backend.User_Management.Domain.Model.Commands;

public record CreateUserCommand(string Username, 
 string Email,
 string Password, 
 string TypeUser, 
TimeSpan MaxDailyReservationHour, 
 string IdentificationUser );