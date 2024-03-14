using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class GetGroceryListHandler : IRequestHandler<GetGroceryListQuery, List<GroceryModel>>
    {
        private readonly IGroceryRepository _repository;

        public GetGroceryListHandler(IGroceryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GroceryModel>> Handle(GetGroceryListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
