using MoviesTVShows.Service.Common.Exceptions;
using System.Net;

namespace MoviesTVShows.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) 
    {
        try
        {
            await _next(context);
        }
        catch (ConflictException ex) // catch if user with that mail already exists
        {
            _logger.LogWarning(ex, ex.Message);

            context.Response.StatusCode =StatusCodes.Status409Conflict;

            await context.Response.WriteAsJsonAsync(new
            {
                statusCode = 409,
                message = ex.Message
            });
        }
        catch (Exception ex) // catch for every unexpected exception
        {
            _logger.LogError(ex, "An unexpected error occurred.");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                statusCode = 500,
                message = "An unexpected error occurred."
            });
        }
    }
}