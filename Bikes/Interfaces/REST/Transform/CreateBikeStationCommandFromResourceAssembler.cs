using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class CreateBikeStationCommandFromResourceAssembler
{
    public static CreateBikeStationCommand ToCommandFromResource(this CreateBikeStationResource resource)
    {
        return new CreateBikeStationCommand(resource.name,resource.address,resource.maxCapacity,resource.location.latitude, resource.location.longitude);
    }
}