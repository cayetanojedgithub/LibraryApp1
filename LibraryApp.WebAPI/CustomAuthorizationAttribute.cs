using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApp.WebAPI
{
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null)
            {
                var apiKey = context.HttpContext.Request.Query["apikey"];
                if (apiKey != "12345")
                {
                    throw new UnauthorizedAccessException("Invalid API Key.");
                }
            }
        }
    }
}
