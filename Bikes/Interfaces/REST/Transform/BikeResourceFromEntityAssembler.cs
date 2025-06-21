using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class BikeResourceFromEntityAssembler
{
    public static BikeResource ToResourceFromEntity(Bike bike)
    {
        return new BikeResource(
            bike.Id,
            bike.available,
            bike.condition,
            bike.bikeStation != null
                ? BikeStationResourceFromEntityAssembler.ToResourceFromEntity(bike.bikeStation)
                : null
        );
    }
}