using backend.Bikes.Interfaces.REST.Transform;
using backend.IAM.Interfaces.REST.Transform;
using backend.Payment.Interfaces.REST.Transform;
using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Interfaces.REST.Resources;

namespace backend.Renting.Interfaces.REST.Transform;

public static class RentResourceFromEntityAssembler
{
    public static RentResource ToResourceFromEntity(Rent rent)
    {
        return new RentResource(
            rent.Id,
            rent.StartTime,
            rent.EndTime,
            rent.Payment != null
                ? PaymentResourceFromEntityAssembler.ToResourceFromEntity(rent.Payment)
                : null,
            rent.user != null
                ? UserResourceFromEntityAssembler.ToResourceFromEntity(rent.user)
                : null,
            rent.bikeStations != null
            ? BikeStationResourceFromEntityAssembler.ToResourceFromEntity(rent.bikeStations)
            : null
                
        );
    }
       
}