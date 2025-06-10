namespace backend.Renting.Domain.Model.Commands;

public record CreateRentCommand( int Id ,
DateTime StartTime,
DateTime EndTime ,
int PaymentId,
int UserId,
int BikeStationStartId,
int BikeStationEndId);