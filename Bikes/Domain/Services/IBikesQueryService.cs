using backend.Bikes.Domain.Model.Queries;
using backend.Bikes.Domain.Model.Aggregates;

namespace backend.Bikes.Domain.Services;

public interface IBikesQueryService
{
    Task<Bike?> Handle(GetBikeByIdQuery query);
    Task<IEnumerable<Bike>> Handle(GetAllBikesQuery query);
    Task<IEnumerable<Bike>> Handle(GetAvailableBikesQuery query);
}