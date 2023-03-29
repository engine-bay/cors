namespace EngineBay.Cors
{
    using EngineBay.Core;

    public class CorsModule : IModule
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            // set CORS policies
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "CORS Policy",
                    policy =>
                    { // todo add this as an env variable
                        policy.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            return services;
        }

        /// <inheritdoc/>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }

        public WebApplication AddMiddleware(WebApplication app)
        {
            // Use CORS policies
            app.UseCors("CORS Policy");

            return app;
        }
    }
}