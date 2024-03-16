using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class GetAllShoppingBagsHandler : IRequestHandler<GetShoppingBagListQuery, List<ShoppingBag>>
    {
        private readonly IShoppingBagRepository _repository;

        public GetAllShoppingBagsHandler(IShoppingBagRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShoppingBag>> Handle(GetShoppingBagListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
