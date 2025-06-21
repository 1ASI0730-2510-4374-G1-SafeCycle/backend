using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Queries;
using backend.Tours.Domain.Repositories;
using backend.Tours.Domain.Services;

namespace backend.Tours.Application.Internal.QueryServices;

public class TourBookingQueryServices(ITourBookingRepository  tourBookingRepository): ITourBookingQueryService
{
    public async Task<TourBooking?> Handle(GetTourBookingByIdQuery query)
    {
        return await tourBookingRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<TourBooking>> Handle(GetAllTourBookingQuery query)
    {
        return await tourBookingRepository.ListAsync();
    }
}