using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Application.Mediat.Dittos.Models;
using Ditto.Application.Mediat.Dittos.Queries;
using Ditto.Common.Models;
using Ditto.Common.Services;
using Ditto.Server.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Ditto.Server.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DittoController : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult<List<DittoModel>>> Get([FromQuery] DittosFilterQuery dittosFilterQuery)
    {
        var response = await Mediator.Send(dittosFilterQuery);
        if(dittosFilterQuery.Limit.HasValue)
            HttpContext.AddPaginationToHeader(total: response.TotalCount, limit: dittosFilterQuery.Limit.Value);
        return Ok(response.Results);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InsertDittoCommand command)
    {
        var dittoId = await Mediator.Send(command);
        return Created($"ditto/ver/{dittoId}", dittoId);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id,[FromBody] UpdateDittoCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteDittoCommand { Id = id });
        return NoContent();
    }
}
