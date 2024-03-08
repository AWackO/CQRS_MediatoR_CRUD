using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Commands
{
    public record InsertGroceryCommand(string Name, Types ProductType) : IRequest<GroceryModel>;

}
