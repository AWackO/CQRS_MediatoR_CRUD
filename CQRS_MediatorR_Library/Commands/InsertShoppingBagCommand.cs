using MediatR;

namespace CQRS_MediatorR_Library.Commands;

public record InsertShoppingBagCommand(string Name) : IRequest<int>;