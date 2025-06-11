using backend.TourBooking.Domain.Model.Commands;
using backend.TourBooking.Interfaces.REST.Resources;

namespace backend.TourBooking.Interfaces.REST.Transform;

public static class UpdateTourBookingCommandFromResourceAssembler
{
    public static UpdateTourBookingCommand ToCommandFromResource(this UpdateTourBookingResource resource)
    {
        return new UpdateTourBookingCommand(resource.Id,resource.date,resource.starthour,resource.endhour,resource.station,resource.tour);
    }
}