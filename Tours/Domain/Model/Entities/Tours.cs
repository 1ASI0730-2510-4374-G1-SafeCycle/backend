using System.ComponentModel.DataAnnotations;
using backend.Tours.Domain.Model.Commands;

namespace backend.Tours.Domain.Model.Entities;

public partial class Tour
{
    protected Tour()
    {
        name = string.Empty;
        hour = string.Empty;
        img = string.Empty;
        price = 0;
    }
    
    public Tour(CreateToursCommand command)
    {
        name = command.name;
        hour = command.hour;
        img = command.img;
        price = command.price;
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string name { get; set; }

    [StringLength(10, MinimumLength = 1)]
    public string hour { get; set; }

   [StringLength(10, MinimumLength = 1)]
    public string img { get; set; }

    [Range(1, 1000)]
    public float price { get; set; }
    
    public void UpdateFromCommand(UpdateToursCommand command)
    {
        name = command.name;
        hour = command.hour;
        img = command.img;
        price = command.price;
    }
}