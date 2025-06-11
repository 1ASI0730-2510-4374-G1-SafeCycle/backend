using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.TourBooking.Domain.Repositories;

namespace backend.TourBooking.Infrastructure.Repository;

public class TourBookingRepository(SafecycleDBContext context) : BaseRepository<Domain.Model.Aggregates.TourBooking>(context), ITourBookingRepository
{
    public Task AddAsync(Domain.Model.Aggregates.TourBooking entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Model.Aggregates.TourBooking entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(Domain.Model.Aggregates.TourBooking entity)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Aggregates.TourBooking> GetTourBookingByStationAsync(string station)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Model.Aggregates.TourBooking>> GetAllTourBookingAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Aggregates.TourBooking> GetTourBookingAsync(int id)
    {
        throw new NotImplementedException();
    }
}