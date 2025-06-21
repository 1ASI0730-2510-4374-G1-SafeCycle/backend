using backend.Payment.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Payment.Domain.Repositories;

public interface IPaymentInformationRepository : IBaseRepository<PaymentInformation>
{
    Task<IEnumerable<PaymentInformation>> GetAllAsync();
    
    Task<PaymentInformation?> GetByIdAsync(int id);
    
    Task<PaymentInformation?> GetByHolder(string holder);
}