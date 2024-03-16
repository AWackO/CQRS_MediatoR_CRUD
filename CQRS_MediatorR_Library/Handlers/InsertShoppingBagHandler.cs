using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers;

public class InsertShoppingBagHandler : IRequestHandler<InsertShoppingBagCommand, int>
{
    private readonly IShoppingBagRepository _repository;

    public InsertShoppingBagHandler(IShoppingBagRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(InsertShoppingBagCommand request, CancellationToken cancellationToken)
    {
        var shoppingBag = new ShoppingBag { Name = request.Name };

        var createdShoppingBag = await _repository.AddAsync(shoppingBag);

        return createdShoppingBag.Id;
    }
}
