using Ocelot.DependencyInjection;
using Ocelot.Middleware;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configuración de Ocelot
        services.AddOcelot();

        // Configuración de autenticación JWT
        services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://your-auth-server.com";  // Cambiar por tu servidor de autenticación
                    options.Audience = "your-api";
                    options.RequireHttpsMetadata = false;
                });

        // Agregar Swagger (opcional)
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway v1"));
        }

        app.UseRouting();

        // Usar autenticación JWT
        app.UseAuthentication();

        // Usar Ocelot para enrutar las solicitudes
        app.UseOcelot().Wait();
    }
}
