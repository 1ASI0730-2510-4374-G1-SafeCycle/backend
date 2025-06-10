using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Queries;

namespace backend.Renting.Domain.Services;

public interface IRentQueryService
{
    Task<IEnumerable<Rent>> Handle(GetAllRentsQuery query);
    Task<Rent?> Handle(GetRentByIdQuery query);
}