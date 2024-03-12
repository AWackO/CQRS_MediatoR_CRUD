using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatorR_Library.Handlers
{
    public class GetGroceryListHandler : IRequestHandler<GetGroceryListQuery, List<GroceryModel>>
    {
        private readonly DataContext _data;

        public GetGroceryListHandler(DataContext data)
        {
            _data = data;
        }
        public async Task<List<GroceryModel>> Handle(GetGroceryListQuery request, CancellationToken cancellationToken)
        {
            var groceries = await _data.Groceries.ToListAsync();
            return groceries;
        }
    }
}
