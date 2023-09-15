using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Servislerinizi burada yapılandırabilirsiniz.
        services.AddSession();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Uygulama yapılandırmanızı burada yapabilirsiniz.
        app.UseSession();
    }
}
