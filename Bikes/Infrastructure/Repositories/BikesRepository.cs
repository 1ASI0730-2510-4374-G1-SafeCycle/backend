using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Bike_Management.Infrastructure.Repositories;

public class BikesRepository(SafecycleDBContext context) : BaseRepository<Bikes.Domain.Model.Aggregates.Bikes>(context), IBikesRepository

{
    public async Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> GetAllBikesAsync()
    {
        return await Context.Set<Bikes.Domain.Model.Aggregates.Bikes>()
            .Include(b => b.bikeStation)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> GetAllAvailableBikesAsync()
    {
        return await Context.Set<Bikes.Domain.Model.Aggregates.Bikes>()
            .Where(b => b.available == true)
            .Include(b => b.bikeStation)
            .ToListAsync();
    }

    public async Task<Bikes.Domain.Model.Aggregates.Bikes?> GetBikeByIdAsync(int id)
    {
        return await Context.Set<Bikes.Domain.Model.Aggregates.Bikes>()
            .Include(b => b.bikeStation)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}