using Ditto.Application.Mediat.Product.Models;
using Ditto.Common.Models;
using MediatR;

namespace Ditto.Application.Mediat.Product.Queries;

public class ProductsQuery : IRequest<PaginationModel<ProductModel>>
{
    public int Page { get; set; }
    public int Limit { get; set; } = 10;
}
