using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Tours.Infrastructure.Repositories;

public class TourBookingRepository(SafecycleDBContext context): BaseRepository<TourBooking>(context), ITourBookingRepository
{
    public Task<IEnumerable<TourBooking>> GetAllBookings()
    {
        throw new NotImplementedException();
    }

    public async Task<TourBooking?> GetBookingById(int id)
    {
        return await Context.Set<TourBooking>()
            .Include(t => t.rent)
            .ThenInclude(r => r.Payment)
            .ThenInclude(p => p.paymentInformation)
            .Include(t => t.rent)
            .ThenInclude(r => r.user)
            .Include(t => t.rent)
            .ThenInclude(r => r.bikeStations)
            .Include(t => t.tour)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}