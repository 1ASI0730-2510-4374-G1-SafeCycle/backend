using backend.Payments.Domain.Model.Queries;
using backend.Payments.Domain.Repositories;
using backend.Payments.Domain.Services;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.Payments.Application.Internal.QueryServices;

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