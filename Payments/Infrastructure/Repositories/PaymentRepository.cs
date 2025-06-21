using backend.Payments.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Payments.Infrastructure.Repositories;

public class PaymentRepository(SafecycleDBContext context) : BaseRepository<Payments.Domain.Model.Aggregates.Payment>(context), IPaymentRepository
{
    public Task<IEnumerable<Payments.Domain.Model.Aggregates.Payment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Payments.Domain.Model.Aggregates.Payment?> GetByIdAsync(int id)
    {
        return await Context.Set<Payments.Domain.Model.Aggregates.Payment>()
            .Include(b => b.paymentInformation)
            .ThenInclude(pi => pi.user)
            .FirstOrDefaultAsync(b => b.id == id);
    }


    public async Task<Payments.Domain.Model.Aggregates.Payment?> GetByPrice(float price)
    {
        return await Context.Set<Payments.Domain.Model.Aggregates.Payment>()
            .Include(b => b.paymentInformation)
            .ThenInclude(pi => pi.user)
            .FirstOrDefaultAsync(b => b.price == price);
    }
}