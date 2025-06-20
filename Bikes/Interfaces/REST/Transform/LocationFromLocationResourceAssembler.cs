using backend.Bikes.Domain.Model.ValueObjects;
using backend.Bikes.Interfaces.REST.Resources;

namespace backend.Bikes.Interfaces.REST.Transform;

public static class LocationFromResourceAssembler
{
    public static Location ToLocation(this LocationResource resource)
    {
        return new Location(resource.latitude, resource.longitude);
    }
}