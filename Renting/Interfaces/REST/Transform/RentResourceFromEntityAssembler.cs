using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Interfaces.REST.Resources;

namespace backend.Renting.Interfaces.REST.Transform;

public static class RentResourceFromEntityAssembler
{
    public static RentResource ToResourceFromEntity(Rent entity)
        => new RentResource(entity.Id, entity.StartTime, entity.EndTime,
            entity.PaymentId, entity.UserId,
            entity.BikeStationEndId, entity.BikeStationStartId);
}