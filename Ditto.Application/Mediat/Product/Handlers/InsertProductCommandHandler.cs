using AutoMapper;
using Ditto.Application.Mediat.Product.Commands;
using Ditto.Common.Repositories;
using product = Ditto.Common.Domain.Product;
using MediatR;
using Ditto.Application.Mediat.Product.Models;

namespace Ditto.Application.Mediat.Product.Handlers;

public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, ProductModel>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public InsertProductCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<ProductModel> Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<product>(request);
        await repositories.Products.InsertAsync(product);
        if(! await repositories.SaveChangesAsync()) throw new Exception("Could not save product");
        return mapper.Map<ProductModel>(product);
    }
}
