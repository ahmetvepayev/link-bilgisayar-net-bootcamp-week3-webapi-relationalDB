using Microsoft.AspNetCore.Mvc;
using Week3.Entities.Concrete;
using Week3.Service.Abstract;

namespace Week3.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>Returns a list of all products</summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAll());
    }

    /// <summary>Returns product with the matching Id</summary>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productService.GetById(id));
    }

    /// <summary>Returns a different product model that references Products, Categories and ProductFeatures tables, using a stored procedure</summary>
    [HttpGet("full")]
    public IActionResult GetFullModels()
    {
        return Ok(_productService.GetFullModels());
    }

    /// <summary>Adds the given product into the DB</summary>
    [HttpPost]
    public IActionResult Add([FromBody]Product product)
    {
        if (!_productService.Add(product))
        {
            return BadRequest();
        }

        return StatusCode(201);
    }

    /// <summary>Updates the given product</summary>
    [HttpPut]
    public IActionResult Update([FromBody]Product product)
    {
        if(!_productService.Update(product))
        {
            return BadRequest();
        }

        return Ok();
    }

    /// <summary>Deletes the given product</summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(!_productService.Delete(id))
        {
            return BadRequest();
        }

        return Ok();
    }
}