using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class UpdateBikeCommandFromResourceAssembler
{
    public static UpdateBikeCommand ToCommandFromResource(this UpdateBikeResource resource)
    {
        return new UpdateBikeCommand(resource.id, resource.condition,resource.available, resource.bikeStationId);
    }
}