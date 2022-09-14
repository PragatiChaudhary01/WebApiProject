using Microsoft.AspNetCore.Mvc;
using StoreList.Models;
using StoreList.Servies;

namespace StoreList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : Controller
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [Route("~/")]
        public IActionResult load()
        {
            return Ok("Welcome to my api");
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_storeService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_storeService.Get(id));
            }
            catch (Exception e)
            {
                return NotFound(new { error = e.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Store storeRequest)
        {
            try
            {
                var store = _storeService.Create(storeRequest);
                return Created("~/stores/" + storeRequest.Id, store);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Store store)
        {
            try
            {
                _storeService.Update(store);
                return Ok(_storeService.Get(store.Id));
            }
            catch (Exception e)
            {
                return NotFound(new { error = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _storeService.Delete(id);
                return Ok(new { message = "Successfully Deleted" });
            }
            catch (Exception e)
            {
                return NotFound(new { error = e.Message });
            }
        }

    }
}
