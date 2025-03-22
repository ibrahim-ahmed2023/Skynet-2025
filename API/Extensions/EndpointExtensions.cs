using API.SignalR;
using Core.Entities;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapControllers();
        endpoints.MapGroup("api").MapIdentityApi<AppUser>(); // api/login
        endpoints.MapHub<NotificationHub>("/hub/notifications");
        endpoints.MapFallbackToController("Index", "Fallback");

        return endpoints;
    }
}
