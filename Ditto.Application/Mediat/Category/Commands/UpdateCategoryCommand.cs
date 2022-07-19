using MediatR;

namespace Ditto.Application.Mediat.Category.Commands;

public class UpdateCategoryCommand: IRequest
{
    public int Id { get; set;}
    public string Name { get; set; }
}
