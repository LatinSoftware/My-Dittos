using AutoMapper;
using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Application.Mediat.Dittos.Queries;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Handlers;

public class DittoByIdQueryHandler : IRequestHandler<DittoByIdQuery, DittoModel>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public DittoByIdQueryHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<DittoModel> Handle(DittoByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await repositories.Dittos.GetByIDAsync(request.Id);
        return mapper.Map<DittoModel>(data);
    }
}
