using CQRS_MediatorR_Library.DTOs;
using CQRS_MediatorR_Library.Models;
using MediatR;

namespace CQRS_MediatorR_Library.Queries;

public record GetAllMeatItemsQuery(Types productType, int minItemCount) : IRequest<List<ShoppingBagDTO>>
{
}
