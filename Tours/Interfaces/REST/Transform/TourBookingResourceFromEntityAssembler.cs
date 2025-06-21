using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class TourBookingResourceFromEntityAssembler
{
    public static TourBookingResource ToResourceFromEntity(Domain.Model.Aggregates.TourBooking tourBooking)=>
    new(tourBooking.Id,tourBooking.date,tourBooking.starthour,tourBooking.endhour,tourBooking.station,tourBooking.tour);
}