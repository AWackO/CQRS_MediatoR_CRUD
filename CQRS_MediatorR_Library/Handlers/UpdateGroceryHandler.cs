using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class UpdateGroceryHandler : IRequestHandler<UpdateGroceryCommand, GroceryModel>
    {
        private readonly DataContext _context;

        public UpdateGroceryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GroceryModel> Handle(UpdateGroceryCommand request, CancellationToken cancellationToken)
        {
            var dbGrocery = await _context.Groceries.FindAsync(request.Id);

            dbGrocery.Name = request.Name;
            dbGrocery.ProductType = request.ProductType;

            await _context.SaveChangesAsync();

            return dbGrocery;

        }
    }
}
