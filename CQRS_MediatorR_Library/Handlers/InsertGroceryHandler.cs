using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DataAccess;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class InsertGroceryHandler : IRequestHandler<InsertGroceryCommand, GroceryModel>
    {
        private readonly IDataAccess _data;

        public InsertGroceryHandler(IDataAccess data)
        {
            _data = data;
        }
        public async Task<GroceryModel> Handle(InsertGroceryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.InsertGrocery(request.Name, request.ProductType));
        }
    }
}
