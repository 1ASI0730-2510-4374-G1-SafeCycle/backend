namespace backend.Tours.Domain.Model.Commands;
 
public record UpdateToursCommand (int id,string name, string hour, string img, float price);
