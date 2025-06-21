using backend.Tours.Domain.Model.Commands;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class CreateTourBookingCommandFromResourceAssembler
{
    public static CreateTourBookingCommand ToCommandFromResource(this CreateTourBookingResource tourBookingResource)
    {
        return new CreateTourBookingCommand(tourBookingResource.date,tourBookingResource.starthour,tourBookingResource.endhour,tourBookingResource.station,tourBookingResource.tour);
    }
}