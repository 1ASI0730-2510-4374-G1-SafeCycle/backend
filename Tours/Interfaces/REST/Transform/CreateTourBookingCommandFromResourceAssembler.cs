using backend.Tours.Domain.Model.Commands;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class CreateTourBookingCommandFromResourceAssembler
{
    public static CreateTourBookingCommand ToCommandFromResource(this CreateTourBookingResource resource)
    {
        return new CreateTourBookingCommand(resource.rentId, resource.tourId);
    }
    
}