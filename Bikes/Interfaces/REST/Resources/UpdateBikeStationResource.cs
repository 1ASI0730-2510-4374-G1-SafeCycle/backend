namespace backend.Bikes.Interfaces.REST.Resources;

public record UpdateBikeStationResource(int Id,string address, LocationResource location, int maxCapacity, string name);