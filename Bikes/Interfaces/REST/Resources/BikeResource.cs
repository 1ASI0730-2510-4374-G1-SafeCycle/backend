namespace backend.Bikes.Interfaces.REST.Resources;

public record BikeResource(int id, string available, string condition, BikeStationResource bikeStation);
