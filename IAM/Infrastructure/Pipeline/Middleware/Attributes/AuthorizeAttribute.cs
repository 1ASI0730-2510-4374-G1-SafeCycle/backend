using backend.IAM.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]

public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var anonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        
        if (anonymous)
        {
            Console.WriteLine("Skipping authorization");
            return;
        }
        
        var user = context.HttpContext.Items["User"] as User;
       
        if (user == null) context.Result = new UnauthorizedResult();
        
    }
}