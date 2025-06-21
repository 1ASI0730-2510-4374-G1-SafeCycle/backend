namespace backend.Renting.Domain.Model.Commands;

public record CreateRentCommand(
DateTime StartTime,
DateTime EndTime ,
int PaymentId,
int UserId,
int BikeStationId);