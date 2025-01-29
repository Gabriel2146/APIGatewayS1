using Microsoft.AspNetCore.Hosting;  // Asegúrate de tener esta referencia
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOcelot();
        services.AddSwaggerGen();
        services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://your-auth-server.com";
                    options.Audience = "your-api";
                    options.RequireHttpsMetadata = false;
                });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)  // Cambia a IWebHostEnvironment
    {

        app.UseMiddleware<AuthenticationMiddleware>();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway v1"));
        }

        app.UseRouting();
        app.UseAuthentication();
        app.UseOcelot().Wait();
    }
}
