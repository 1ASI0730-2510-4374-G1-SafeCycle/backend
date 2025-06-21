namespace backend.Renting.Interfaces.REST.Resources;

public record CreateRentResource(
    DateTime StartTime,
    DateTime EndTime ,
    int PaymentId,
    int UserId,
    int BikeStationId);