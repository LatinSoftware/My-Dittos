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
        if(! await repositories.Products.Exist(request.Id)) throw new Exception("Product do not exist");
        var product = mapper.Map<product>(request);
        repositories.Products.Update(product);
        if(! await repositories.SaveChangesAsync()) throw new Exception("Could not save product");
        return Unit.Value;
    }
}
