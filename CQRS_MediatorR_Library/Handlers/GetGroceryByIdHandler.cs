using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class GetGroceryByIdHandler : IRequestHandler<GetGroceryByIdQuery, GroceryModel>
    {
        private readonly IMediator _mediator;

        public GetGroceryByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<GroceryModel> Handle(GetGroceryByIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new GetGroceryListQuery());

            var output = results.FirstOrDefault(x => x.Id == request.id);

            return output;
        }
    }
}
