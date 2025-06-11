
using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class BikeStationResourceFromEntityAssembler
{
    public static BikeStationResource ToResourceFromEntity(BikeStations bikeStation)=>
    new BikeStationResource(bikeStation.Id,bikeStation.address,new LocationResource(
                bikeStation.Location.Latitude,
                bikeStation.Location.Longitude
        ),bikeStation.maxCapacity,bikeStation.name);
}

