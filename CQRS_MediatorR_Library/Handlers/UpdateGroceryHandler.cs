using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DataAccess;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class UpdateGroceryHandler : IRequestHandler<UpdateGroceryCommand, GroceryModel>
    {
        private readonly IDataAccess _data;

        public UpdateGroceryHandler(IDataAccess data)
        {
            _data = data;
        }
        public async Task<GroceryModel> Handle(UpdateGroceryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.UpdateGrocery(request.Id, request.Name, request.ProductType));
        }
    }
}
