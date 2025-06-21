using backend.Shared.Domain.Repositories;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.Payments.Domain.Repositories;

public interface IPaymentInformationRepository : IBaseRepository<PaymentInformation>
{
    Task<IEnumerable<PaymentInformation>> GetAllAsync();
    
    Task<PaymentInformation?> GetByIdAsync(int id);
    
    Task<PaymentInformation?> GetByHolder(string holder);
}