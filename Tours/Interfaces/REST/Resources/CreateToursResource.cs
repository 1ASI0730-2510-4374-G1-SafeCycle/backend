namespace backend.Tours.Interfaces.REST.Resources;

public record CreateToursResource(string name, string hour, string img, float price);