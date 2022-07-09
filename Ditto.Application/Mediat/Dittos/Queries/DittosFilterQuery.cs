using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Common.Models;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Queries;

public class DittosFilterQuery : IRequest<PaginationModel<DittoModel>>
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public DateTime? OrderDate { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }
}
