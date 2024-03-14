using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class UpdateGroceryHandler : IRequestHandler<UpdateGroceryCommand, GroceryModel>
    {
        private readonly IGroceryRepository _repository;

        public UpdateGroceryHandler(IGroceryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GroceryModel> Handle(UpdateGroceryCommand request, CancellationToken cancellationToken)
        {
            var groceryToUpdate = await _repository.GetByIdAsync(request.Id);

            groceryToUpdate.Name = request.Name;
            groceryToUpdate.ProductType = request.ProductType;

            await _repository.UpdateAsync(groceryToUpdate);

            return groceryToUpdate;
        }
    }
}
