using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Payment.Infrastructure.Repositories;

public class PaymentRepository(SafecycleDBContext context) : BaseRepository<Payments>(context), IPaymentRepository
{
    public Task<IEnumerable<Payments>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Payments> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Payments> GetByPrice(float price)
    {
        throw new NotImplementedException();
    }
}