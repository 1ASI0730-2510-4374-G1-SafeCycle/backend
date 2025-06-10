using backend.Renting.Domain.Model.Commands;
using backend.Renting.Interfaces.REST.Resources;

namespace backend.Renting.Interfaces.REST.Transform;

public static class CreateRentCommandFromResourceAssembler
{
    public static CreateRentCommand ToCommandFromResource(this RentResource resource)
    {
        return new CreateRentCommand(resource.Id,
            resource.StartTime,
            resource.EndTime,
            resource.PaymentId,
            resource.UserId,
            resource.BikeStationStartId,
            resource.BikeStationEndId);
    }
}