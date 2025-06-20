using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Interfaces.REST.Resources;


namespace backend.Bikes.Interfaces.REST.Transform;

public static class CreateBikeCommandFromResourceAssembler
{
    public static CreateBikeCommand ToCommandFromResource(this CreateBikeResource resource)
    {
        return new CreateBikeCommand(resource.condition, resource.available, resource.bikeStationId);
    }
}