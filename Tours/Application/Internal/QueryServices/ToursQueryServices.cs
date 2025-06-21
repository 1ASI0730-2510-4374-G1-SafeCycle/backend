using backend.Tours.Domain.Model.Entities;
using backend.Tours.Domain.Model.Queries;
using backend.Tours.Domain.Repositories;
using backend.Tours.Domain.Services;

namespace backend.Tours.Application.Internal.QueryServices;

public class ToursQueryServices(IToursRepository toursRepository): IToursQueryService
{
    public async Task<Tour?> Handle(GetTourByIdQuery query)
    {
        return await toursRepository.GetToursByIdAsync(query.id);
    }

    public async Task<IEnumerable<Tour>> Handle(GetAllToursQuery query)
    {
        return await toursRepository.GetAllToursAsync();
    }
}