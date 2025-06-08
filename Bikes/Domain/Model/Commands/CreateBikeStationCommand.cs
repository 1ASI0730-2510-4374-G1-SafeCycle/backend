
namespace backend.Bikes.Domain.Model.Commands;

public record CreateBikeStationCommand(string name, string address, int maxCapacity, float lat, float lng);