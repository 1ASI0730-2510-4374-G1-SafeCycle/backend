using backend.Tours.Domain.Model.Queries;
namespace backend.Tours.Domain.Services;

public interface ITourBookingQueryService
{
    Task<Model.Aggregates.TourBooking?> Handle(GetTourBookingByIdQuery query);
    
    Task<IEnumerable<Model.Aggregates.TourBooking>> Handle(GetAllTourBookingQuery query);
}