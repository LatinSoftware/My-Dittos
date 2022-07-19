using AutoMapper;
using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Application.Mediat.Dittos.Models;

namespace Ditto.Application.Profiles;

public class DittoProfile : Profile
{
    public DittoProfile()
    {
        CreateMap<InsertDittoCommand, Ditto.Common.Domain.Ditto>();
        CreateMap<UpdateDittoCommand, Ditto.Common.Domain.Ditto>();
        CreateMap<Ditto.Common.Domain.Ditto, DittoModel>();
    }
}
