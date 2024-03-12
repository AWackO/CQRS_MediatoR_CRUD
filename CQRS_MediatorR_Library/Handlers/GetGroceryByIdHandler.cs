using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers;

public class GetGroceryByIdHandler : IRequestHandler<GetGroceryByIdQuery, GroceryModel>
{
    private readonly DataContext _context;

    public GetGroceryByIdHandler(DataContext context)
    {
        _context = context;
    }
    public async Task<GroceryModel> Handle(GetGroceryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Groceries.FindAsync(request.id);

        return result;
    }
}
