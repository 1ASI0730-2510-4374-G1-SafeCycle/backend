using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Renting.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Commands;
using backend.Tours.Domain.Model.Entities;
namespace backend.Tours.Domain.Model.Aggregates;

public partial class TourBooking
{
    protected TourBooking()
    {
        tourId = 0;
        rentId = 0;
    }

    public TourBooking(CreateTourBookingCommand command)
    {
        tourId = command.tourId;
        rentId = command.rentId;
    }
    public int Id { get; set; }
    
    [Required]
    public int tourId { get; set; }
    [Required]
    public int rentId { get; set; }
    
    [Required]
    [ForeignKey("tourId")]
    public required Tour tour {get; set;}
    
    [Required]
    [ForeignKey("rentId")]
    public required Rent rent{get; set;}

}