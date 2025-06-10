namespace backend.Tours.Domain.Model.Commands;

public record CreateToursCommand(string name, string hour, string img, float price);