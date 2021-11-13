using Microsoft.AspNetCore.Mvc;
using PostServiceBackendApi.Entities;
using PostServiceBackendApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackendApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            return Ok(await _postService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Post post)
        {
            return Ok(await _postService.AddPostAsync(post));
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePost(Post post)
        {
            await _postService.UpdatePostAsync(post);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
    }
}
