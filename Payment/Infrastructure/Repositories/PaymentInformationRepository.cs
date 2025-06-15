using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Payment.Infrastructure.Repositories;

public class PaymentInformationRepository(SafecycleDBContext context) : BaseRepository<PaymentInformation>(context), IPaymentInformationRepository
{
    public Task<IEnumerable<PaymentInformation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PaymentInformation> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentInformation> GetByHolder(string holder)
    {
        throw new NotImplementedException();
    }
}