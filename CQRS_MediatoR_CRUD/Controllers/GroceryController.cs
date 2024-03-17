using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CQRS_MediatoR_CRUD.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GroceryController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroceryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<GroceryModel>> Get(GetGroceryListQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<GroceryModel> Get(GetGroceryByIdQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<GroceryModel> Post([FromBody] InsertGroceryCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<GroceryModel> Put(int id, [FromBody] GroceryModel value)
    {
        var model = new UpdateGroceryCommand(value.Id = id, value.Name, value.ProductType);
        return await _mediator.Send(model);
    }

    [HttpDelete("{id}")]
    public async Task<GroceryModel> Delete(DeleteGroceryCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("meat-items")]
    public async Task<ActionResult<List<GroceryModel>>> GetMeatItems(GetAllMeatItemsQuery query)
    {
        var meatItems = await _mediator.Send(query);
        return Ok(meatItems);
    }
}
