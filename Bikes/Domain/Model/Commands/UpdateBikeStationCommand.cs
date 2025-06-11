namespace backend.Bikes.Domain.Model.Commands;

public record UpdateBikeStationCommand(int id,string name, string address, int maxCapacity, float lat, float lng)
{
    
}