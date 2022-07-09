using System.Text.Json.Serialization;
using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Common.Enums;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Commands;

public class UpdateDittoCommand : IRequest<DittoModel>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public int FrecuencyTime { get; set; }
    public FrecuencyEnum Frecuency { get; set; }
    public int? Max { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime BuyedDate { get; set; }
    public double RealPrice { get; set; }
}
