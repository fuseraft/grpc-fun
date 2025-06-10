using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using GrpcService.Services;

namespace GrpcService;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGrpc();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<GreeterService>();
        });
    }
}
