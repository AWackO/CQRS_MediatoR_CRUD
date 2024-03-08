using CQRS_MediatorR_Library.DataAccess;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class GetGroceryListHandler : IRequestHandler<GetGroceryListQuery, List<GroceryModel>>
    {
        private readonly IDataAccess _data;

        public GetGroceryListHandler(IDataAccess data)
        {
            _data = data;
        }
        public Task<List<GroceryModel>> Handle(GetGroceryListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetGroceries());
        }
    }
}
