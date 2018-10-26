using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreServices.Models;
using CoreServices.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository postRepository;
        public PostController(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await postRepository.GetCategories();
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);

        }

        [HttpGet]
        [Route("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postRepository.GetPosts();
            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet]
        [Route("GetPost")]
        public async Task<IActionResult> GetPost(int? postId)
        {
            if(postId==null)
            {
                return BadRequest();
            }

            var post = await postRepository.GetPost(postId);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost([FromBody]Post model)
        {
            if (ModelState.IsValid)
            {
                var postId = await postRepository.AddPost(model);
                if (postId > 0)
                {
                    return Ok(postId);
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int? postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }

            int result = await postRepository.DeletePost(postId);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpPost]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromBody]Post model)
        {
            if (ModelState.IsValid)
            {
                await postRepository.UpdatePost(model);
                return Ok();
            }

            return BadRequest();
        }

    }
}
