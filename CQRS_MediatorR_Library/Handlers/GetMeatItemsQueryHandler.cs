using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

public class GetMeatItemsQueryHandler : IRequestHandler<GetMeatItemsQuery, List<GroceryModel>>
{
    private readonly IGroceryRepository _repository;

    public GetMeatItemsQueryHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GroceryModel>> Handle(GetMeatItemsQuery request, CancellationToken cancellationToken)
    {
        var allItems = await _repository.GetAllAsync();

        var meatItems = allItems.Where(g => g.ProductType == Types.Meat).ToList();

        return meatItems;
    }
}
