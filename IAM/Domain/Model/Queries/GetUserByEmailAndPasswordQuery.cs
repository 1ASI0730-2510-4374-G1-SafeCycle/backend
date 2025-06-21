namespace backend.IAM.Domain.Model.Queries;

public record GetUserByEmailAndPasswordQuery(string email, string password);