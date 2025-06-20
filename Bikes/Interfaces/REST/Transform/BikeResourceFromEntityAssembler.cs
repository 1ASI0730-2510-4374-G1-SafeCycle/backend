using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class BikeResourceFromEntityAssembler
{
    public static BikeResource ToResourceFromEntity(Domain.Model.Aggregates.Bikes bikes) =>
    new BikeResource(bikes.Id,bikes.available,bikes.condition, BikeStationResourceFromEntityAssembler.ToResourceFromEntity(bikes.bikeStation));
}