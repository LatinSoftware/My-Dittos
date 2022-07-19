using MediatR;

namespace Ditto.Application.Mediat.Category.Commands;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}
