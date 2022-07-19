using Ditto.Application.Mediat.Category.Models;
using MediatR;

namespace Ditto.Application.Mediat.Category.Queries;

public class CategoryByIdQuery : IRequest<CategoryModel>
{
    public int Id { get; set; }
}
