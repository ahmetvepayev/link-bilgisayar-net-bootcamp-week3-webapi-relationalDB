using Microsoft.AspNetCore.Mvc;
using Week3.Entities.Concrete;
using Week3.Service.Abstract;

namespace Week3.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class ProductFeatureController : ControllerBase
{
    private readonly IProductFeatureService _productFeatureService;

    public ProductFeatureController(IProductFeatureService productFeatureService)
    {
        _productFeatureService = productFeatureService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productFeatureService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productFeatureService.GetById(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody]ProductFeature productFeature)
    {
        if (!_productFeatureService.Add(productFeature))
        {
            return BadRequest();
        }

        return StatusCode(201);
    }

    [HttpPut]
    public IActionResult Update([FromBody]ProductFeature productFeature)
    {
        if(!_productFeatureService.Update(productFeature))
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(!_productFeatureService.Delete(id))
        {
            return BadRequest();
        }

        return Ok();
    }
}