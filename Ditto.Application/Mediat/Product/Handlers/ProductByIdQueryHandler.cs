using AutoMapper;
using Ditto.Application.Mediat.Product.Models;
using Ditto.Application.Mediat.Product.Queries;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Product.Handlers;

public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductModel>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public ProductByIdQueryHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<ProductModel> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        if(!await repositories.Products.Exist(request.Id)) throw new Exception("Product do not exist");
        var product = await repositories.Products.GetByIDAsync(request.Id);
        return mapper.Map<ProductModel>(product);
    }
}
