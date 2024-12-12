namespace API_Versioning.Middleware
{
    public class ObsoleteApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<string, DateTime> _deprecatedEndpoints;

        public ObsoleteApiMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _deprecatedEndpoints = configuration
                .GetSection("DeprecatedEndpoints")
                .Get<Dictionary<string, DateTime>>() ?? new Dictionary<string, DateTime>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var currentTime = DateTime.UtcNow;

            var fullPath = $"{context.Request.Path}{context.Request.QueryString}";

            if (_deprecatedEndpoints.TryGetValue(fullPath, out var deprecationDate))
            {
                if (currentTime >= deprecationDate)
                {
                    context.Response.StatusCode = StatusCodes.Status410Gone;
                    await context.Response.WriteAsync($"This endpoint was deprecated and is no longer accessible as of {deprecationDate:u}.");
                    return;
                }
                else
                {
                    context.Response.OnStarting(() =>
                    {
                        context.Response.Headers.Add("Warning", $"299 - \"This endpoint will be deprecated on {deprecationDate:u}\"");
                        return Task.CompletedTask;
                    });
                }
            }
            await _next(context);
        }

    }
}
