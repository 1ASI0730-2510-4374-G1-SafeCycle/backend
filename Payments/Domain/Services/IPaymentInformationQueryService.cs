using backend.Payments.Domain.Model.Queries;
using PaymentInformation = backend.Payments.Domain.Model.Aggregates.PaymentInformation;

namespace backend.Payments.Domain.Services;

public interface IPaymentInformationQueryService
{
    Task<PaymentInformation?> Handle(GetPaymentInformationByIdQuery query);

    Task<PaymentInformation?> Handle(GetPaymentInformationByHolderQuery query);

    Task<IEnumerable<PaymentInformation>> Handle(GetAllPaymentInformationQuery query);
}