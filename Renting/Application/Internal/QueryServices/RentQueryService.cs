using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Queries;
using backend.Renting.Domain.Repositories;
using backend.Renting.Domain.Services;

namespace backend.Renting.Application.Internal.QueryServices;

public class RentQueryService(IRentRepository repository) : IRentQueryService
{
    public async Task<IEnumerable<Rent>> Handle(GetAllRentsQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Rent?> Handle(GetRentByIdQuery query)
    {
        return await repository.FindByIdAsync(query.id);
    }
}