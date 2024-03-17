using AutoMapper;
using CQRS_MediatorR_Library.DTOs;
using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.Mappings;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ShoppingBag, ShoppingBagDTO>();
        CreateMap<GroceryModel, GroceryDTO>();
    }
}

