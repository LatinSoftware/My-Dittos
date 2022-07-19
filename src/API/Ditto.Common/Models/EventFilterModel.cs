namespace Ditto.Common.Models;

public class EventFilterModel
{

    public string EventId { get; set; }
    public string Q { get; set; }
    public DateTime DateFrom { get; set; } = new DateTime(year: DateTime.Today.Year, 1, 1);
    public DateTime DateTo { get; set; } = DateTime.Today;

}
