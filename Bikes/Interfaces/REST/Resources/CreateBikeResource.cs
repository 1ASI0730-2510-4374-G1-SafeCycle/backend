namespace backend.Bikes.Interfaces.REST.Resources;

public record CreateBikeResource(bool available, string condition, int bikeStationId);
