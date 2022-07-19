using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Common.Enums;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Commands;

public class InsertDittoCommand : IRequest<int>
{
    public string Name { get; set; }
    public int FrecuencyTime { get; set; }
    public FrecuencyEnum Frecuency { get; set; }
    public int? Max { get; set; }
    public DateTime OrderDate { get; set; }
    public double ExpectedPrice { get; set; }
    public int ProductId { get; set; }
}
