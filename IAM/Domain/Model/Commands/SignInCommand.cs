namespace backend.IAM.Domain.Model.Commands;

public record SignInCommand(string email, string password);