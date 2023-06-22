using Blog.Business.Services.Abstract;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/post
        [HttpGet]
        public List<Post> Get()
        {
            return _postService.GetAll();
        }

        // GET api/post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST api/post
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            _postService.Insert(post);

            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        // PUT api/post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            if (post == null || id != post.Id)
            {
                return BadRequest();
            }

            var existingPost = _postService.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            _postService.Update(post);

            return NoContent();
        }

        // DELETE api/post/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPost = _postService.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            _postService.DeleteById(id);

            return NoContent();
        }
    }
}
