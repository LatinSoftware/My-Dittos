using AutoMapper;
using Ditto.Application.Mediat.Product.Commands;
using Ditto.Common.Repositories;
using product = Ditto.Common.Domain.Product;
using MediatR;

namespace Ditto.Application.Mediat.Product.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public UpdateProductCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repositories.Products.GetByIDAsync(request.Id);
        if(product == null) throw new KeyNotFoundException();
        product.CategoryId = request.CategoryId > 0 ? request.CategoryId : product.CategoryId;
        product.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : product.Name;
        product.ImageUrl = !string.IsNullOrEmpty(request.ImageUrl) ? request.ImageUrl : product.ImageUrl;
        if(! await repositories.SaveChangesAsync()) throw new Exception("Could not save product");
        return Unit.Value;
    }
}
