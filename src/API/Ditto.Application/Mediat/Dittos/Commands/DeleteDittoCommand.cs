using MediatR;

namespace Ditto.Application.Mediat.Dittos.Commands;

public class DeleteDittoCommand : IRequest
{
    public int Id { get; set; }
}
