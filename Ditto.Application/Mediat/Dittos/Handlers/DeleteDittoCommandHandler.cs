using AutoMapper;
using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Handlers;

public class DeleteDittoCommandHandler : IRequestHandler<DeleteDittoCommand>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public DeleteDittoCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteDittoCommand request, CancellationToken cancellationToken)
    {
        if(! await repositories.Dittos.ExistAsync(request.Id)) 
            throw new KeyNotFoundException("Ditto no encontrado");
        
        repositories.Dittos.Delete(request.Id);
        if(! await repositories.SaveChangesAsync())
            throw new Exception("Could not delete the item");
        return Unit.Value;
    }

}
