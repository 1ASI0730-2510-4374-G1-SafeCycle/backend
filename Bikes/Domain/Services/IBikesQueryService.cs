using backend.Bike_Management.Domain.Model.Queries;
using backend.Bikes.Domain.Model.Aggregates;

namespace backend.Bike_Management.Domain.Services;

public interface IBikesQueryService
{
    Task<BikesManagement?> Handle(GetBikeByIdQuery query);
    Task<IEnumerable<BikesManagement>> Handle(GetAllBikesQuery query);
    Task<IEnumerable<BikesManagement>> Handle(GetAvailableBikesQuery query);
}