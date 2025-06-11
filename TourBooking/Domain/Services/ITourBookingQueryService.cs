using backend.TourBooking.Domain.Model.Queries;
namespace backend.TourBooking.Domain.Services;

public interface ITourBookingQueryService
{
    Task<Model.Aggregates.TourBooking?> Handle(GetTourBookingByIdQuery query);
    
    Task<IEnumerable<Model.Aggregates.TourBooking>> Handle(GetAllTourBookingQuery query);
    
    Task<Domain.Model.Aggregates.TourBooking> Handle(GetTourBookingByStation query);
}