using Ditto.Application.Mediat.Category.Models;
using MediatR;

namespace Ditto.Application.Mediat.Category.Queries;

public class CategoriesQuery : IRequest<List<CategoryModel>>
{
}
