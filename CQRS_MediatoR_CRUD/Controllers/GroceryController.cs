using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS_MediatoR_CRUD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroceryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<GroceryController>
        [HttpGet]
        public async Task<List<GroceryModel>> Get()
        {
            return await _mediator.Send(new GetGroceryListQuery());
        }

        // GET api/<GroceryController>/5
        [HttpGet("{id}")]
        public async Task<GroceryModel> Get(int id)
        {
            return await _mediator.Send(new GetGroceryByIdQuery(id));
        }

        // POST api/<GroceryController>
        [HttpPost]
        public async Task<GroceryModel> Post([FromBody] GroceryModel value)
        {
            var model = new InsertGroceryCommand(value.Name, value.ProductType);
            return await _mediator.Send(model);
        }

        // PUT api/<GroceryController>/5
        [HttpPut("{id}")]
        public async Task<GroceryModel> Put(int id, [FromBody] GroceryModel value)
        {
            var model = new UpdateGroceryCommand(value.Id = id, value.Name, value.ProductType);
            return await _mediator.Send(model);
        }

        // DELETE api/<GroceryController>/5
        [HttpDelete("{id}")]
        public async Task<GroceryModel> Delete(int id)
        {
            var model = new DeleteGroceryCommand(id);
            return await _mediator.Send(model);
        }

        [HttpGet("meat-items")]
        public async Task<ActionResult<List<GroceryModel>>> GetMeatItems(Types type, int minItemCount)
        {
            var query = new GetAllMeatItemsQuery(type, minItemCount);
            var meatItems = await _mediator.Send(query);
            return Ok(meatItems);
        }
    }
}
