using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class BikeResourceFromEntityAssembler
{
    public static BikeResource ToResourceFromEntity(BikesManagement bikesManagement) =>
    new BikeResource(bikesManagement.Id,bikesManagement.available,bikesManagement.condition, bikesManagement.bikeStationId);
}