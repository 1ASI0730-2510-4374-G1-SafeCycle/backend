using backend.Shared.Domain.Repositories;
using backend.Tours.Domain.Model.Aggregates;

namespace backend.Tours.Domain.Repositories;


public interface ITourBookingRepository: IBaseRepository<Model.Aggregates.TourBooking>;