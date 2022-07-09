using AutoMapper;
using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Handlers;

public class UpdateDittoCommandHandler : IRequestHandler<UpdateDittoCommand>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public UpdateDittoCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDittoCommand request, CancellationToken cancellationToken)
    {
        if(! await repositories.Dittos.ExistAsync(request.Id)) throw new KeyNotFoundException("Ditto no encontrado");
        
        var ditto = await repositories.Dittos.GetByIDAsync(request.Id);
        if(!string.IsNullOrEmpty(request.Name)) ditto.Name = request.Name;
        if(request.FrecuencyTime.HasValue) ditto.FrecuencyTime = request.FrecuencyTime.Value;
        if(request.Frecuency.HasValue) ditto.Frecuency = request.Frecuency.Value;
        if(request.Max.HasValue) ditto.Max = request.Max.Value;
        if(request.OrderDate.HasValue) ditto.OrderDate = request.OrderDate.Value;
        if(request.BuyedDate.HasValue) ditto.BuyedDate = request.BuyedDate.Value;
        if(request.RealPrice.HasValue) ditto.RealPrice = request.RealPrice.Value;
        if(! await repositories.SaveChangesAsync())
            throw new Exception("Could not save changes");
        return Unit.Value;
    }

}
