using Microsoft.AspNetCore.Mvc;

public class ApiDeprecationMiddleware
{
    private readonly RequestDelegate _next;

    public ApiDeprecationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Check if an API version is set by the versioning system
            var apiVersion = context.GetRequestedApiVersion()?.ToString();

            if (apiVersion == "1.0" || apiVersion == "1") // Example: Deprecating version 1.0
            {
                // Add warning header to the response
                context.Response.Headers.Add("X-API-Warning",
                    "This version is deprecated and will be removed on 2024-12-31.");
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the exception (optional, using a logging framework like Serilog, NLog, etc.)
            // Example: _logger.LogError(ex, "Error in ApiDeprecationMiddleware");

            // Set the status code and content for the error response
            context.Response.StatusCode = 500; // Internal Server Error
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                message = "An error occurred while processing the request.",
                error = ex.Message // Optional: You can provide the exception message or a generic message
            };

            // Write the error response as JSON
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
