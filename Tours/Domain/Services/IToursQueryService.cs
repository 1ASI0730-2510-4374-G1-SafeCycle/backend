using backend.Tours.Domain.Model.Queries;

namespace backend.Tours.Domain.Services;

public interface IToursQueryService
{
    Task<Model.Entities.Tours?> Handle(GetTourByIdQuery query);

    Task<IEnumerable<Model.Entities.Tours>> Handle(GetAllToursQuery query);
}