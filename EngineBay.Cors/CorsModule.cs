namespace EngineBay.Cors
{
    using EngineBay.Core;

    public class CorsModule : BaseModule
    {
        public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            // set CORS policies
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "CORS Policy",
                    policy =>
                    {
                        policy.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            return services;
        }

        public override WebApplication AddMiddleware(WebApplication app)
        {
            // Use CORS policies
            app.UseCors("CORS Policy");

            return app;
        }
    }
}