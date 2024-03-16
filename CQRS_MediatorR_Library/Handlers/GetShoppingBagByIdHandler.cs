using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers;

public class GetShoppingBagByIdHandler : IRequestHandler<GetShoppingBagByIdQuery, ShoppingBag>
{
    private readonly IShoppingBagRepository _shoppingBagRepository;

    public GetShoppingBagByIdHandler(IShoppingBagRepository shoppingBagRepository)
    {
        _shoppingBagRepository = shoppingBagRepository;
    }

    public async Task<ShoppingBag> Handle(GetShoppingBagByIdQuery request, CancellationToken cancellationToken)
    {
        return await _shoppingBagRepository.GetByIdAsync(request.Id);
    }
}
