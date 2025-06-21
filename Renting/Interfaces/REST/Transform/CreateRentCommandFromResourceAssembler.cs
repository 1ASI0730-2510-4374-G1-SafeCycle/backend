using backend.Renting.Domain.Model.Commands;
using backend.Renting.Interfaces.REST.Resources;

namespace backend.Renting.Interfaces.REST.Transform;

public static class CreateRentCommandFromResourceAssembler
{
    public static CreateRentCommand ToCommandFromResource(this CreateRentResource resource)
    {
        return new CreateRentCommand(
            resource.StartTime,
            resource.EndTime,
            resource.PaymentId,
            resource.UserId,
            resource.BikeStationId);
    }
}