using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.CategoryService;
using WebAPI.Services.ItemService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Add(Category newCategory)
        {
            try
            {
                await _service.AddAsync(newCategory);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
    }
}
