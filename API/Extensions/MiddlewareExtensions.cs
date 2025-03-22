using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app)
        {
            // Exception Handling Middleware
            app.UseExceptionMiddleware();

            // CORS Middleware
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                .WithOrigins("http://localhost:4200", "https://localhost:4200"));

            // Authentication & Authorization Middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Static Files Middleware
            app.UseDefaultFiles();
            app.UseStaticFiles();

            return app;
        }
    }
}
