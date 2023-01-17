using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Core.DTOs.Concrete.Product;

namespace SkinetECommerce.WebAPI.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllAsync(x => x.ProductBrand, x => x.ProductType);
        if (result.IsSuccess)
        {
            var productToReturnDto = _mapper.Map<List<ProductToReturnDto>>(result.Data);
            return Ok(productToReturnDto);
        }

        return NotFound(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productService.GetByIdAsync(id, x => x.ProductBrand, x => x.ProductType);
        if (result.IsSuccess)
        {
            var productToReturnDto = _mapper.Map<ProductToReturnDto>(result.Data);
            return Ok(productToReturnDto);
        }

        return NotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductAddDto productAddDto)
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