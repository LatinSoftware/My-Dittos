using AutoMapper;
using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Common.Exceptions;
using Ditto.Common.Models;
using Ditto.Common.Repositories;
using Ditto.Common.Services;
using MediatR;

namespace Ditto.Application.Mediat.Dittos.Handlers;

public class InsertDittoCommandHandler : IRequestHandler<InsertDittoCommand, int>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;
    private readonly ICalendarService calendarService;

    public InsertDittoCommandHandler(IUnitOfWork repositories, IMapper mapper, ICalendarService calendarService)
    {
        this.repositories = repositories;
        this.mapper = mapper;
        this.calendarService = calendarService;
    }

    public async Task<int> Handle(InsertDittoCommand request, CancellationToken cancellationToken)
    {
        if(! await repositories.Products.Exist(request.ProductId))
            throw new BusinessException("Product don't exist in products list");
        var ditto = mapper.Map<Ditto.Common.Domain.Ditto>(request);
        var product = await repositories.Products.GetByIDAsync(request.ProductId);
        // sent event to calendar
        ditto.CalendarEventId = await calendarService.InsertEvent(new CalendarEventModel{
            Summary = $"Buy {product.Name}",
            Description = "I need to buy 5 of product every 3 month",
            Start = request.OrderDate,
            End = request.OrderDate
         });
        await repositories.Dittos.InsertAsync(ditto);
        if(! await repositories.SaveChangesAsync())
            throw new Exception("Could not save changes");
        return ditto.Id;
    }
}
