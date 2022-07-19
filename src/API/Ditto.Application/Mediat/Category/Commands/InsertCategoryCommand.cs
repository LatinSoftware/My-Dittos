using MediatR;

namespace Ditto.Application.Mediat.Category.Commands;

public class InsertCategoryCommand : IRequest<int>
{
    public string Name { get; set; }
}
