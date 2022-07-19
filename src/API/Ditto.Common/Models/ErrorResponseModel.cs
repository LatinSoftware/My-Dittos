namespace Ditto.Common.Models;

public class ErrorResponseModel
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Error {get; set;}
}
