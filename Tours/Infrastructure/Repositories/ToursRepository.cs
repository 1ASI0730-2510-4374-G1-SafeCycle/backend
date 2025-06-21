using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.Tours.Domain.Model.Entities;
using backend.Tours.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Tours.Infrastructure.Repositories;

public class ToursRepository(SafecycleDBContext context) : BaseRepository<Tour>(context), IToursRepository
{
    public Task<IEnumerable<Tour>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tour>> GetAllToursAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Tour?> GetToursByIdAsync(int id)
    {
        return await Context.Set<Tour>()
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}