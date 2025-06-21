namespace backend.Bikes.Interfaces.REST.Resources;

public record CreateBikeStationResource(string address, LocationResource location, int maxCapacity, string name);