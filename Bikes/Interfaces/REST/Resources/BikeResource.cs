namespace backend.Bikes.Interfaces.REST.Resources;

public record BikeResource(int id, bool available, string condition, BikeStationResource? bikeStation);
