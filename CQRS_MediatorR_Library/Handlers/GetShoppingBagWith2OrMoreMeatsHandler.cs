using AutoMapper;
using CQRS_MediatorR_Library.DTOs;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers;

public class GetShoppingBagWith2OrMoreMeatsHandler : IRequestHandler<GetAllMeatItemsQuery, List<ShoppingBagDTO>>
{
    private readonly IShoppingBagRepository _repository;
    private readonly IMapper _mapper;

    public GetShoppingBagWith2OrMoreMeatsHandler(IShoppingBagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    async Task<List<ShoppingBagDTO>> IRequestHandler<GetAllMeatItemsQuery, List<ShoppingBagDTO>>.Handle(GetAllMeatItemsQuery request, CancellationToken cancellationToken)
    {
        var shoppingBags = await _repository.GetShoppingBagWith2OrMoreMeatsOnly(request.productType, request.minItemCount);
        return _mapper.Map<List<ShoppingBagDTO>>(shoppingBags);
    }
}
