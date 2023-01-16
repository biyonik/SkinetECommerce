using Microsoft.AspNetCore.Mvc;
using SkinetECommerce.Business.Abstract;

namespace SkinetECommerce.WebAPI.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync(x => x.ProductBrand, x => x.ProductType);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var productResult = await _productService.GetByIdAsync(id);
        return Ok(productResult);
    }

    [HttpPost]
    public async Task<IActionResult> Add()
    {
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        return Ok();
    }
}