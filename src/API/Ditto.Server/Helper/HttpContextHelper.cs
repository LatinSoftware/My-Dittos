namespace Ditto.Server.Helper;

public static class HttpContextHelper
{
    public static void AddPaginationToHeader(this HttpContext context, int total, int limit)
    {
        var totalPages = Math.Abs(total / limit);
        context.Response.Headers.Add("TotalData", total.ToString());
        context.Response.Headers.Add("TotalPages", totalPages.ToString());

    }
}
