using System.Text.Json.Serialization;
using Ditto.Application.Mediat.Product.Models;
using Ditto.Common.Enums;

namespace Ditto.Application.Mediat.Dittos.Models;

public class DittoModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FrecuencyTime { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public FrecuencyEnum Frecuency { get; set; }
    public int? Max { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime BuyedDate { get; set; }
    public DateTime NextOrderDate { get; set; }
    public string CalendarEventId { get; set; }
    public double ExpectedPrice { get; set; }
    public double RealPrice { get; set; }
    public int ProductId { get; set; }
    public ProductModel Product { get; set; }
}
