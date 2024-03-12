using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class InsertGroceryHandler : IRequestHandler<InsertGroceryCommand, GroceryModel>
    {
        private readonly DataContext _context;

        public InsertGroceryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GroceryModel> Handle(InsertGroceryCommand request, CancellationToken cancellationToken)
        {
            var newGrocery = new GroceryModel
            {
                Name = request.Name,
                ProductType = request.ProductType
            };

            _context.Groceries.Add(newGrocery);
            await _context.SaveChangesAsync();

            return newGrocery;
        }
    }
}
