using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Common.Models;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Queries;

public class DittosFilterQuery : DittoFilterModel, IRequest<PaginationModel<DittoModel>>
{
    
}
