using backend.Payment.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Payment.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payments>
{
    Task<IEnumerable<Payments>> GetAllAsync();
    Task<Payments?> GetByIdAsync(int id);
    Task<Payments?> GetByPrice(float price);
}