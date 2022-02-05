namespace Root
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Required to configure OpenFaaS function health-check.
            services.AddHealthChecks();

            services.AddTransient<FunctionHandler.FunctionHandler>();

            //Configure you dependencies here ...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Adds health-checks middleware only for OpenFaaS well-know url.
            app.UseHealthChecks("/_/health");

            // Adds function handler
            app.Run(async context =>
            {
                var functionHandler = context.RequestServices
                    .GetRequiredService<FunctionHandler.FunctionHandler>();

                try
                {
                    await functionHandler.HandlerAsync(context);
                }
                catch (Exception exception)
                {
                    context.Response.StatusCode = 500;

                    await context.Response.WriteAsync(exception.ToString());
                }
            });
        }
    }
}