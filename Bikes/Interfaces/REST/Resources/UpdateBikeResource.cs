namespace backend.Bikes.Interfaces.REST.Resources;


public record UpdateBikeResource(int id,string condition, bool available, int bikeStationId);