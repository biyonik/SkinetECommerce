using AutoMapper;
using SkinetECommerce.Core.DTOs.Concrete.Product;
using SkinetECommerce.Core.Entities.Concrete;

namespace SkinetECommerce.Core.Helpers;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(dest => dest.ProductBrandName, ex => ex.MapFrom(e => e.ProductBrand.Name))
            .ForMember(dest => dest.ProductTypeName, ex => ex.MapFrom(e => e.ProductType.Name))
            .ReverseMap();

        CreateMap<Product, ProductAddDto>()
            .ForMember(d => d.ProductBrandName, op => op.)
    }
}