using backend.Bikes.Domain.Model.Commands;

namespace backend.Bikes.Domain.Services;

public interface IBikesCommandService
{
    Task<Bikes.Domain.Model.Aggregates.Bikes?> Handle(CreateBikeCommand command);
    
    Task<Bikes.Domain.Model.Aggregates.Bikes?> Handle(UpdateBikeCommand command);
}