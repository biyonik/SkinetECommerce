using Microsoft.AspNetCore.Mvc;
using SkinetECommerce.Business.Abstract;

namespace SkinetECommerce.WebAPI.Controllers;

public class ProductBrandsController: BaseController
{
    private readonly IProductBrandService _productBrandService;

    public ProductBrandsController(IProductBrandService productBrandService)
    {
        _productBrandService = productBrandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var productBrandsResult = await _productBrandService.GetAllAsync();
        return Ok(productBrandsResult);
    }
}