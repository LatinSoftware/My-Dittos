using Ditto.Common.Enums;

namespace Ditto.Common.Domain;

public class Ditto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FrecuencyTime { get; set; }
    public FrecuencyEnum Frecuency { get; set; }
    public int? Max { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime BuyedDate { get; set; }
    public DateTime NextOrderDate { get; set; }
    public string CalendarEventId { get; set; }
    public double ExpectedPrice { get; set; }
    public double RealPrice { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
