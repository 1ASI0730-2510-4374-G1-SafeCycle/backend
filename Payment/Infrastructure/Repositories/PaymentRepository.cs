using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Payment.Infrastructure.Repositories;

public class PaymentRepository(SafecycleDBContext context) : BaseRepository<Payments>(context), IPaymentRepository
{
    public Task<IEnumerable<Payments>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Payments?> GetByIdAsync(int id)
    {
        return await Context.Set<Payments>()
            .FirstOrDefaultAsync(b => b.id == id);
    }

    public async Task<Payments?> GetByPrice(float price)
    {
        return await Context.Set<Payments>()
            .FirstOrDefaultAsync(b => b.price == price);
    }
}