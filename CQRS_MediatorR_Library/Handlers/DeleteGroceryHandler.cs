using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers
{
    public class DeleteGroceryHandler : IRequestHandler<DeleteGroceryCommand, GroceryModel>
    {
        private readonly DataContext _context;

        public DeleteGroceryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GroceryModel> Handle(DeleteGroceryCommand request, CancellationToken cancellationToken)
        {
            var dbGrocery = await _context.Groceries.FindAsync(request.Id);

            var deletedGrocery = new GroceryModel
            {
                Id = dbGrocery.Id,
                Name = dbGrocery.Name,
                ProductType = dbGrocery.ProductType
            };

            _context.Groceries.Remove(dbGrocery);
            await _context.SaveChangesAsync();

            return deletedGrocery;
        }
    }
}
