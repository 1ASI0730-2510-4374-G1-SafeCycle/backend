using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Queries;
using backend.Payment.Domain.Repositories;
using backend.Payment.Domain.Services;

namespace backend.Payment.Application.Internal.QueryServices;

public class PaymentInformationQueryServices(IPaymentInformationRepository paymentInformationRepository): IPaymentInformationQueryService    
{
    public async Task<PaymentInformation?> Handle(GetPaymentInformationByIdQuery query)
    {
        return await paymentInformationRepository.GetByIdAsync(query.id);
    }

    public async Task<PaymentInformation?> Handle(GetPaymentInformationByHolderQuery query)
    {
        return await paymentInformationRepository.GetByHolder(query.holder);
    }

    public async Task<IEnumerable<PaymentInformation>> Handle(GetAllPaymentInformationQuery query)
    {
        return await paymentInformationRepository.GetAllAsync(); 
    }
}