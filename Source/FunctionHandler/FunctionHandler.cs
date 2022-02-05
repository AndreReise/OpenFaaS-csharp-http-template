using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FunctionHandler
{
    public class FunctionHandler
    {
        private readonly ILogger<FunctionHandler> logger;

        public FunctionHandler(ILogger<FunctionHandler> logger)
        {
            this.logger = logger;
        }

        public async Task HandlerAsync(HttpContext context)
        {
            logger.LogTrace("Starting function execution.");

            await context.Response.WriteAsync("Hello world!")
                .ConfigureAwait(false);

            logger.LogTrace("Function has been executed.");
        }
    }
}