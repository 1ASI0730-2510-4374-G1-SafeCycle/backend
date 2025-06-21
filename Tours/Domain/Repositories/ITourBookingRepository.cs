using backend.Shared.Domain.Repositories;
using backend.Tours.Domain.Model.Aggregates;

namespace backend.Tours.Domain.Repositories;


public interface ITourBookingRepository : IBaseRepository<TourBooking>
{
    Task<IEnumerable<TourBooking>> GetAllBookings();
    
    Task<TourBooking?> GetBookingById(int id);
}