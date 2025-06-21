using backend.Shared.Domain.Repositories;

namespace backend.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payments.Domain.Model.Aggregates.Payment>
{
    Task<IEnumerable<Payments.Domain.Model.Aggregates.Payment>> GetAllAsync();
    Task<Payments.Domain.Model.Aggregates.Payment?> GetByIdAsync(int id);
    Task<Payments.Domain.Model.Aggregates.Payment?> GetByPrice(float price);
}