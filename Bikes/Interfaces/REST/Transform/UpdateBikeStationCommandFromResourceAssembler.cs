using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class UpdateBikeStationCommandFromResourceAssembler
{
    public static UpdateBikeStationCommand ToCommandFromResource(this UpdateBikeStationResource resource)
    {
        return new UpdateBikeStationCommand(resource.Id,resource.name,resource.address,resource.maxCapacity,resource.location.ToLocation());
    }
}