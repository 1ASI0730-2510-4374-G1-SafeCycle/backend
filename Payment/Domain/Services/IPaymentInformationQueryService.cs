using backend.Payment.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Queries;

namespace backend.Payment.Domain.Services;

public interface IPaymentInformationQueryService
{
    Task<PaymentInformation?> Handle(GetPaymentInformationByIdQuery query);

    Task<PaymentInformation?> Handle(GetPaymentInformationByHolderQuery query);

    Task<IEnumerable<PaymentInformation>> Handle(GetAllPaymentInformationQuery query);
}