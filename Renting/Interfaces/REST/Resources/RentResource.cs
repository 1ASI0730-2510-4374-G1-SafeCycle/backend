namespace backend.Renting.Interfaces.REST.Resources;

public record RentResource( int Id ,
    DateTime StartTime,
    DateTime EndTime ,
    int PaymentId,
    int UserId,
    int BikeStationStartId,
    int BikeStationEndId);