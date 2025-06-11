using backend.Shared.Domain.Repositories;

namespace backend.TourBooking.Domain.Repositories;


public interface ITourBookingRepository: IBaseRepository<Model.Aggregates.TourBooking>
{
    
    Task<IEnumerable<Model.Aggregates.TourBooking>> GetAllTourBookingAsync();
    
    Task<Model.Aggregates.TourBooking> GetTourBookingAsync(int id);
    
    Task<Model.Aggregates.TourBooking> GetTourBookingByStationAsync(string station);
}