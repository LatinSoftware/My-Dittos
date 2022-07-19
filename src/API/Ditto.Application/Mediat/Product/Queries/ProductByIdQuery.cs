using Ditto.Application.Mediat.Product.Models;
using MediatR;

namespace Ditto.Application.Mediat.Product.Queries;

public class ProductByIdQuery : IRequest<ProductModel>
{
    public int Id { get; set; }
}
