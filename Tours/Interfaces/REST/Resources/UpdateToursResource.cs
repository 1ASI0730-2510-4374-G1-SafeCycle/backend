namespace backend.Tours.Interfaces.REST.Resources;

public record UpdateToursResource(int Id, string name, string hour, string img, float price);