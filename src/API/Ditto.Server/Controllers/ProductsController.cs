using Ditto.Application.Mediat.Product.Commands;
using Ditto.Application.Mediat.Product.Models;
using Ditto.Application.Mediat.Product.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Ditto.Server.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductsController : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult<List<ProductModel>>> Get([FromQuery] ProductsQuery productsQuery)
    {
        var response = await Mediator.Send(productsQuery);
        return Ok(response.Results);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ProductModel>>> Get(int id)
    {
        var response = await Mediator.Send(new ProductByIdQuery{ Id = id });
        if(response == null) return NotFound();
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] InsertProductCommand command)
    {
        var response = await Mediator.Send(command);
        return Created("", response);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Put(int id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;
        await Mediator.Send(command);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        await Mediator.Send(new DeleteProductCommand{Id = id});
        return Ok();
    }
}
