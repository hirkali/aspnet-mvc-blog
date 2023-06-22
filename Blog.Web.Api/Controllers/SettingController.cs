using Blog.Business.Services.Abstract;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        // GET: api/Setting
        [HttpGet]
        public IActionResult Get()
        {
            var settings = _settingService.GetAll();
            return Ok(settings);
        }

        // GET: api/Setting/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var setting = _settingService.GetById(id);
            if (setting == null)
            {
                return NotFound();
            }
            return Ok(setting);
        }

        // POST: api/Setting
        [HttpPost]
        public IActionResult Post([FromBody] Setting setting)
        {
            _settingService.Insert(setting);
            return CreatedAtAction(nameof(Get), new { id = setting.Id }, setting);
        }

        // PUT: api/Setting/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Setting setting)
        {
            if (id != setting.Id)
            {
                return BadRequest();
            }

            _settingService.Update(setting);
            return NoContent();
        }

        // DELETE: api/Setting/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _settingService.DeleteById(id);
            return NoContent();
        }
    }
}
