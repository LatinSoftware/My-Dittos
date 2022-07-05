using AutoMapper;
using Ditto.Application.Mediat.Product.Models;
using Ditto.Application.Mediat.Product.Queries;
using Ditto.Common.Models;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Product.Handlers;

public class ProductsQueryHandler : IRequestHandler<ProductsQuery, PaginationModel<ProductModel>>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public ProductsQueryHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<PaginationModel<ProductModel>> Handle(ProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repositories.Products.GetAsync(filter: f => !string.IsNullOrEmpty(request.Filter) ? f.Name.ToLower().Contains(request.Filter.ToLower()) : f.Name != "" 
        && request.CategoryId > 0 ? f.CategoryId == request.CategoryId : f.CategoryId > 0, 
        orderBy: x => x.OrderBy(p => p.CategoryId).OrderBy(p => p.Name), includeProperties: "Category", skip: (request.Page - 1) * request.Limit, take: request.Limit);
        
        return new PaginationModel<ProductModel>(mapper.Map<List<ProductModel>>(products.Results), products.TotalCount);
    }
}
