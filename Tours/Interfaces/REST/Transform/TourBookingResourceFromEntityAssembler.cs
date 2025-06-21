using backend.Renting.Interfaces.REST.Transform;
using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public class TourBookingResourceFromEntityAssembler
{
    public static TourBookingResource ToResourceFromEntity(TourBooking tourBooking)
    {
        return new TourBookingResource(
            tourBooking.Id, 
            tourBooking.rent != null 
                ? RentResourceFromEntityAssembler.ToResourceFromEntity(tourBooking.rent) 
                : null, 
             tourBooking.tour != null
            ? ToursResourceFromEntityAssembler.ToResourceFromEntity(tourBooking.tour) 
            : null
        );}
       
}