using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DataAccess;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class DeleteGroceryHandler : IRequestHandler<DeleteGroceryCommand, GroceryModel>
    {
        private readonly IDataAccess _data;

        public DeleteGroceryHandler(IDataAccess data)
        {
            _data = data;
        }

        public async Task<GroceryModel> Handle(DeleteGroceryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.DeleteGrocery(request.Id));
        }
    }
}
