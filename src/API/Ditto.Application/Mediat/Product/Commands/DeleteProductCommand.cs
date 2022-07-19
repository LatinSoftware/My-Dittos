using MediatR;

namespace Ditto.Application.Mediat.Product.Commands;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}
