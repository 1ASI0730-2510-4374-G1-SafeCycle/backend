using backend.IAM.Domain.Model.Commands;
using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public static  class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource signInResource)
    {
        return new SignInCommand(signInResource.Email, signInResource.Password);
    }
}