using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Services.ItemService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllAsync()
        {
            var result = await _service.GetAllItemsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Add(Item newItem)
        {
            try
            {
                await _service.AddAsync(newItem);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}
