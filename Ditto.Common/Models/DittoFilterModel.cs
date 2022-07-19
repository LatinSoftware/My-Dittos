namespace Ditto.Common.Models;

public class DittoFilterModel
{
    public string Name { get; set; }
    public int? ProductId { get; set; }
    public DateTime? OrderDate { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }
}
