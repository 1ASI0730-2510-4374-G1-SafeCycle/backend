using backend.Bikes.Interfaces.REST.Resources;
using backend.IAM.Interfaces.REST.Resources;
using backend.Payment.Interfaces.REST.Resources;

namespace backend.Renting.Interfaces.REST.Resources;

public record RentResource( int Id ,
    DateTime StartTime,
    DateTime EndTime ,
    PaymentResource? PaymentId,
    UserResource? UserId,
    BikeStationResource? BikeStationId
    );