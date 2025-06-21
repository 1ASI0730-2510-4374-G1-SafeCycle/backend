using backend.Tours.Domain.Model.Commands;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class UpdateTourBookingCommandFromResourceAssembler
{
    public static UpdateTourBookingCommand ToCommandFromResource(this UpdateTourBookingResource resource)
    {
        return new UpdateTourBookingCommand(resource.Id,resource.date,resource.starthour,resource.endhour,resource.station,resource.tour);
    }
}