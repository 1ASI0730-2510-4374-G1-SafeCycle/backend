using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Queries;

namespace backend.Payment.Domain.Services;

public interface IPaymentQueryService
{
    Task<Payments?> Handle(GetPaymentByIdQuery query);

    Task<Payments?> Handle(GetPaymentByPriceQuery query);
    
    Task<IEnumerable<Payments>> Handle(GetAllPaymentsQuery query);
}