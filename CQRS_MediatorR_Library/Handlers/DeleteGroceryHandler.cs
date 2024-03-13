﻿using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Repositories;
using MediatR;

namespace CQRS_MediatorR_Library.Handlers;

public class DeleteGroceryHandler : IRequestHandler<DeleteGroceryCommand, GroceryModel>
{
    private readonly IGroceryRepository<GroceryModel> _repository;

    public DeleteGroceryHandler(IGroceryRepository<GroceryModel> repository)
    {
        _repository = repository;
    }

    public async Task<GroceryModel> Handle(DeleteGroceryCommand request, CancellationToken cancellationToken)
    {
        var groceryToDelete = await _repository.GetByIdAsync(request.Id);

        await _repository.DeleteAsync(groceryToDelete);

        return groceryToDelete;
    }
}