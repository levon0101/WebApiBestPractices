using Microsoft.AspNetCore.Builder;
using WebApiBestPractices.Middleware;

namespace WebApiBestPractices.Extantions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
