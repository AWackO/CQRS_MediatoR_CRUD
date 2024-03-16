using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Queries;

public record GetMeatItemsQuery : IRequest<List<GroceryModel>>
{
}
