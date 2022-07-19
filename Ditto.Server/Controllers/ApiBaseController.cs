using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ditto.Server.Controllers;

public class ApiBaseController : ControllerBase
{
    private IMediator mediator;
    public IMediator Mediator
    {
        get
        {
            return mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        }
    }
}
