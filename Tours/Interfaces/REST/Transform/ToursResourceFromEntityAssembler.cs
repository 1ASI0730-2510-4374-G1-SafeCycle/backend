using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class ToursResourceFromEntityAssembler
{
    public static ToursResource ToResourceFromEntity(Domain.Model.Entities.Tours entity)=>
        new ToursResource(entity.Id,entity.name,entity.hour,entity.img,entity.price);
}