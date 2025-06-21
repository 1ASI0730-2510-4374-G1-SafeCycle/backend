namespace backend.IAM.Domain.Model.Commands;

public record CreateUserCommand(string Username, 
 string Email,
 string Password, 
 string TypeUser, 
TimeSpan MaxDailyReservationHour, 
 string IdentificationUser );