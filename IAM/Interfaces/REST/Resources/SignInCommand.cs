namespace backend.IAM.Interfaces.REST.Resources;

public record SignInCommand(string Username, string Password,string Email);