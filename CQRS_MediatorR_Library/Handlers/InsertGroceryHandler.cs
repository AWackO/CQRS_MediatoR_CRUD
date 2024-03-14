using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class InsertGroceryHandler : IRequestHandler<InsertGroceryCommand, GroceryModel>
    {
        private readonly IGroceryRepository _repository;

        public InsertGroceryHandler(IGroceryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GroceryModel> Handle(InsertGroceryCommand request, CancellationToken cancellationToken)
        {
            var newGrocery = new GroceryModel
            {
                Name = request.Name,
                ProductType = request.ProductType
            };

            await _repository.AddAsync(newGrocery);

            return newGrocery;
        }
    }
}
