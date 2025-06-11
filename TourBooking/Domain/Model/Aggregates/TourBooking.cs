using System.ComponentModel.DataAnnotations;
using backend.TourBooking.Domain.Model.Commands;

namespace backend.TourBooking.Domain.Model.Aggregates;

public partial class TourBooking
{
    protected TourBooking()
    {
        date = string.Empty;
        starthour = string.Empty;
        endhour = string.Empty;
        station = string.Empty;
        tour = string.Empty;
    }

    public TourBooking(CreateTourBookingCommand command)
    {
        date = command.date;
        starthour = command.starthour;
        endhour = command.endhour;
        station = command.station;
        tour = command.tour;
    }
    
    public int Id { get; set; }
    
    [Required]
    [StringLength(10, MinimumLength = 1)]
    public string date { get; set; }
    
    [StringLength(10, MinimumLength = 1)]
    public string starthour { get; set; }
    
    [StringLength(10, MinimumLength = 1)]
    public string endhour { get; set; }
    
    [StringLength(25, MinimumLength = 1)]
    public string station { get; set; }
    
    [StringLength(100, MinimumLength = 1)]
    public string tour { get; set; }
}