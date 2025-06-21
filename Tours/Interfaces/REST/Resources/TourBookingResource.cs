using backend.Renting.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Resources;

public record TourBookingResource(int Id, RentResource? rent, ToursResource? tour);