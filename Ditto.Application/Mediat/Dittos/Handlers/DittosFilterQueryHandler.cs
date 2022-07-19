using AutoMapper;
using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Application.Mediat.Dittos.Queries;
using Ditto.Common.Models;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Handlers;

public class DittosFilterQueryHandler : IRequestHandler<DittosFilterQuery, PaginationModel<DittoModel>>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public DittosFilterQueryHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<PaginationModel<DittoModel>> Handle(DittosFilterQuery request, CancellationToken cancellationToken)
    {
        var data = await repositories.Dittos.FilterAsync(request);
        return new PaginationModel<DittoModel>(mapper.Map<List<DittoModel>>(data.Results), data.TotalCount);
    }
}
