using Microsoft.AspNetCore.Mvc;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Core.Entities.Concrete;

namespace SkinetECommerce.WebAPI.Controllers;

public class ProductTypesController: BaseController
{
    private readonly IProductTypeService _productTypeManager;

    public ProductTypesController(IProductTypeService productTypeManager)
    {
        _productTypeManager = productTypeManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var productTypesResult = await _productTypeManager.GetAllAsync();
        return Ok(productTypesResult);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var productTypeResult = await _productTypeManager.GetByIdAsync(id);
        return Ok(productTypeResult);
    }
}