using backend.Payments.Domain.Model.Queries;

namespace backend.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<Payments.Domain.Model.Aggregates.Payment?> Handle(GetPaymentByIdQuery query);

    Task<Payments.Domain.Model.Aggregates.Payment?> Handle(GetPaymentByPriceQuery query);
    
    Task<IEnumerable<Payments.Domain.Model.Aggregates.Payment>> Handle(GetAllPaymentsQuery query);
}