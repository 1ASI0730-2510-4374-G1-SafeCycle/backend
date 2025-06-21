using backend.Payments.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.Payments.Infrastructure.Repositories;

public class PaymentInformationRepository(SafecycleDBContext context) : BaseRepository<PaymentInformation>(context), IPaymentInformationRepository
{
    public Task<IEnumerable<PaymentInformation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PaymentInformation?> GetByIdAsync(int id)
    {
        return await Context.Set<PaymentInformation>()
            .Include(r => r.user)
            .FirstOrDefaultAsync(b => b.id == id);
    }

    public async Task<PaymentInformation?> GetByHolder(string holder)
    {
        return await Context.Set<PaymentInformation>()
            .FirstOrDefaultAsync(b => b.holder == holder);
    }
}