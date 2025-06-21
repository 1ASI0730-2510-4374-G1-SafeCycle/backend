using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Repositories;

namespace backend.Tours.Infrastructure.Repositories;

public class TourBookingRepository(SafecycleDBContext context): BaseRepository<TourBooking>(context), ITourBookingRepository;