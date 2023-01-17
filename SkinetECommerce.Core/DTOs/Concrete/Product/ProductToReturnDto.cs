using SkinetECommerce.Core.DTOs.Abstract;

namespace SkinetECommerce.Core.DTOs.Concrete.Product;

public class ProductToReturnDto: IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureUrl { get; set; }
    public string ProductBrandName { get; set; }
    public string ProductTypeName { get; set; }
}