using backend.Bike_Management.Domain.Model.Queries;
using backend.Bikes.Domain.Model.Aggregates;

namespace backend.Bike_Management.Domain.Services;

public interface IBikesQueryService
{
    Task<Bikes.Domain.Model.Aggregates.Bikes?> Handle(GetBikeByIdQuery query);
    Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> Handle(GetAllBikesQuery query);
    Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> Handle(GetAvailableBikesQuery query);
}