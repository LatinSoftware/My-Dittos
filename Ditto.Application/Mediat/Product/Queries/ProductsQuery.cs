using Ditto.Application.Mediat.Product.Models;
using Ditto.Common.Models;
using MediatR;

namespace Ditto.Application.Mediat.Product.Queries;

public class ProductsQuery : IRequest<PaginationModel<ProductModel>>
{
    public string Filter { get; set; }
    public int CategoryId { get; set; }
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;
}
