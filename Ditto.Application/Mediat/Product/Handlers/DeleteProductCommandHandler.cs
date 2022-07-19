using AutoMapper;
using Ditto.Application.Mediat.Product.Commands;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Product.Handlers;

public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand>
{
    private readonly IUnitOfWork repositories;
    public DeleteProductCommandHandler(IUnitOfWork repositories)
    {
        this.repositories = repositories;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if(! await repositories.Products.Exist(request.Id)) throw new Exception("Product do not exist");
        repositories.Products.Delete(request.Id);
        if(! await repositories.SaveChangesAsync()) throw new Exception("Could not delete the product");
        return Unit.Value;
    }
}
