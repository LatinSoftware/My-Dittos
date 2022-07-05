using Ditto.Application.Mediat.Category.Commands;
using Ditto.Application.Mediat.Category.Models;
using Ditto.Application.Mediat.Category.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Ditto.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult<List<CategoryModel>>> Get()
    {
        var response = await Mediator.Send(new CategoriesQuery{});
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<CategoryModel>>> Get(int id)
    {
        var response = await Mediator.Send(new CategoryByIdQuery{ Id = id });
        if(response == null) return NoContent();
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody]InsertCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Created("", response);
    }
    [HttpPut]
    public async Task<ActionResult<int>> Put([FromBody]UpdateCategoryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    [HttpDelete]
    public async Task<ActionResult<int>> Delete(int id)
    {
        await Mediator.Send(new DeleteCategoryCommand{Id = id});
        return Ok();
    }
}
