using Microsoft.AspNetCore.Mvc;
using Week3.Entities.Concrete;
using Week3.Service.Abstract;

namespace Week3.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>Returns a list of all categories</summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetAll());
    }

    /// <summary>Returns category with the matching Id</summary>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_categoryService.GetById(id));
    }

    /// <summary>Adds the given category into the DB</summary>
    [HttpPost]
    public IActionResult Add([FromBody]Category category)
    {
        if (!_categoryService.Add(category))
        {
            return BadRequest();
        }

        return StatusCode(201);
    }

    /// <summary>Updates the given category</summary>
    [HttpPut]
    public IActionResult Update([FromBody]Category category)
    {
        if(!_categoryService.Update(category))
        {
            return BadRequest();
        }

        return Ok();
    }

    /// <summary>Deletes the given category</summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(!_categoryService.Delete(id))
        {
            return BadRequest();
        }

        return Ok();
    }
}