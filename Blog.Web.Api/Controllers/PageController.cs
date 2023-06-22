using Blog.Business.Services.Abstract;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        // GET: api/Page
        [HttpGet]
        public IActionResult Get()
        {
            var pages = _pageService.GetAll();
            return Ok(pages);
        }

        // GET: api/Page/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var page = _pageService.GetById(id);
            if (page == null)
            {
                return NotFound();
            }
            return Ok(page);
        }

        // POST: api/Page
        [HttpPost]
        public IActionResult Post([FromBody] Page page)
        {
            _pageService.Insert(page);
            return CreatedAtAction(nameof(Get), new { id = page.Id }, page);
        }

        // PUT: api/Page/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }

            _pageService.Update(page);
            return NoContent();
        }

        // DELETE: api/Page/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pageService.DeleteById(id);
            return NoContent();
        }
    }
}
