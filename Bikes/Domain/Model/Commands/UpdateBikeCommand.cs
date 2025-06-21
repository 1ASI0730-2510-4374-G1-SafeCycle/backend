namespace backend.Bikes.Domain.Model.Commands;

public record UpdateBikeCommand(int id,string condition, bool available, int bikeStationId); 