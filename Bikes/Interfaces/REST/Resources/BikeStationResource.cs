
namespace backend.Bikes.Interfaces.REST.Resources;

public record BikeStationResource(int Id, string address, LocationResource location, int maxCapacity, string name);