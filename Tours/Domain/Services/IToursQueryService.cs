using backend.Tours.Domain.Model.Entities;
using backend.Tours.Domain.Model.Queries;

namespace backend.Tours.Domain.Services;

public interface IToursQueryService
{
    Task<Tour?> Handle(GetTourByIdQuery query);

    Task<IEnumerable<Tour>> Handle(GetAllToursQuery query);
}