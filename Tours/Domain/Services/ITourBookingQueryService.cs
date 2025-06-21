using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Queries;
namespace backend.Tours.Domain.Services;

public interface ITourBookingQueryService
{
    Task<TourBooking?> Handle(GetTourBookingByIdQuery query);
    
    Task<IEnumerable<TourBooking>> Handle(GetAllTourBookingQuery query);
}