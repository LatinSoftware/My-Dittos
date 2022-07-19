namespace Ditto.Common.Models;

public class CalendarEventModel
{
    public string Id { get; set;}
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End {get; set; }
}
