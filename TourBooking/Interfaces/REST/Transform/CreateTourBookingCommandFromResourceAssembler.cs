using backend.TourBooking.Domain.Model.Commands;
using backend.TourBooking.Interfaces.REST.Resources;

namespace backend.TourBooking.Interfaces.REST.Transform;

public static class CreateTourBookingCommandFromResourceAssembler
{
    public static CreateTourBookingCommand ToCommandFromResource(this CreateTourBookingResource tourBookingResource)
    {
        return new CreateTourBookingCommand(tourBookingResource.date,tourBookingResource.starthour,tourBookingResource.endhour,tourBookingResource.station,tourBookingResource.tour);
    }
}