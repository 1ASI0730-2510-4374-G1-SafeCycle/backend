using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Bikes.Infrastructure.Repositories;

public class BikesRepository(SafecycleDBContext context) : BaseRepository<Bike>(context), IBikesRepository

{
    public async Task<IEnumerable<Bike>> GetAllBikesAsync()
    {
        return await Context.Set<Bike>()
            .Include(b => b.bikeStation)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bike>> GetAllAvailableBikesAsync()
    {
        return await Context.Set<Bike>()
            .Where(b => b.available == true)
            .Include(b => b.bikeStation)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bike>> GetAllAvailableBikesByIdAsync(int id)
    {
        return await Context.Set<Bike>()
            .Where(b => b.BikeStationId == id && b.available == true)
            .ToListAsync();

    }

    public async Task<Bike?> GetBikeByIdAsync(int id)
    {
        return await Context.Set<Bike>()
            .Include(b => b.bikeStation)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}