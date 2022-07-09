using AutoMapper;
using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Common.Exceptions;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Handlers;

public class InsertDittoCommandHandler : IRequestHandler<InsertDittoCommand, int>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public InsertDittoCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }

    public async Task<int> Handle(InsertDittoCommand request, CancellationToken cancellationToken)
    {
        if(! await repositories.Products.Exist(request.ProductId))
            throw new BusinessException("Product don't exist in products list");
        var ditto = mapper.Map<Ditto.Common.Domain.Ditto>(request);
        await repositories.Dittos.InsertAsync(ditto);
        if(! await repositories.SaveChangesAsync())
            throw new Exception("Could not save changes");
        return ditto.Id;
    }
}
