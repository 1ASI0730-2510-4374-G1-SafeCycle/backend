using backend.Tours.Domain.Model.Entities;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class ToursResourceFromEntityAssembler
{
    public static ToursResource ToResourceFromEntity(Tour tour)=>
        new ToursResource(tour.Id,tour.name,tour.hour,tour.img,tour.price);
}