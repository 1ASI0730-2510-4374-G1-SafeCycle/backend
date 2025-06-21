using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Queries;
using backend.Payment.Domain.Repositories;
using backend.Payment.Domain.Services;

namespace backend.Payment.Application.Internal.QueryServices;

public class PaymentQueryServices(IPaymentRepository paymentRepository): IPaymentQueryService
{
    public async Task<Payments?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.GetByIdAsync(query.id);
    }

    public async Task<Payments?> Handle(GetPaymentByPriceQuery query)
    {
        return await paymentRepository.GetByPrice(query.price); 
    }

    public async Task<IEnumerable<Payments>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.GetAllAsync();
    }
}