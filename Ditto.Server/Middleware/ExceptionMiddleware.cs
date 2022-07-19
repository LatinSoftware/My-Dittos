using System.Net;
using Ditto.Common.Exceptions;
using Ditto.Server.Error;
using FluentValidation;
using Newtonsoft.Json;

namespace Ditto.Server.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var result = string.Empty;
            switch(error)
            {
                case BusinessException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode: response.StatusCode, details: e.Message));
                    break;
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode: response.StatusCode));
                    break;
                case ValidationException validationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode: response.StatusCode, message: error.Message, details: validationJson));
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode: response.StatusCode, message: error.Message, details: error.StackTrace));
                    break;
            }
            await response.WriteAsync(result);
        }
    }
}
