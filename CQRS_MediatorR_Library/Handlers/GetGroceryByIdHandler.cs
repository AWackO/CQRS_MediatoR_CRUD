using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class GetGroceryByIdHandler : IRequestHandler<GetGroceryByIdQuery, GroceryModel>
    {
        private readonly IGroceryRepository _repository;

        public GetGroceryByIdHandler(IGroceryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GroceryModel> Handle(GetGroceryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.id);
        }
    }
}
