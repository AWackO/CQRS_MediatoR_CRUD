using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Commands
{
    public record DeleteGroceryCommand(int Id) : IRequest<GroceryModel>;

}
