using Ditto.Application.Mediat.Dittos.Models;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Queries;

public class DittoByIdQuery : IRequest<DittoModel>
{
    public int Id { get; set; }
}
