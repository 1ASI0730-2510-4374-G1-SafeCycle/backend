using backend.Payments.Domain.Model.Queries;
using backend.Payments.Domain.Repositories;
using backend.Payments.Domain.Services;

namespace backend.Payments.Application.Internal.QueryServices;

public class PaymentQueryServices(IPaymentRepository paymentRepository): IPaymentQueryService
{
    public async Task<Payments.Domain.Model.Aggregates.Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.GetByIdAsync(query.id);
    }

    public async Task<Payments.Domain.Model.Aggregates.Payment?> Handle(GetPaymentByPriceQuery query)
    {
        return await paymentRepository.GetByPrice(query.price); 
    }

    public async Task<IEnumerable<Payments.Domain.Model.Aggregates.Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.GetAllAsync();
    }
}