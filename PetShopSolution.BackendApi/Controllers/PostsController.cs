using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopSolution.Application.Catalog.Posts;
using PetShopSolution.ViewModels.Catalog.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController( IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPostByUserId([FromQuery]GetPostPagingByUserId request)
        {
            var posts = await _postService.GetAllPostByUserId(request);
            return Ok(posts);
        }
        [HttpGet("{postID}")]
        public async Task<IActionResult> GetPostById(int postID)
        {
            var post = await _postService.GetPostById(postID);
            return Ok(post);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]PostUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectdResult = await _postService.Update(request);
            if(affectdResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete(int postID)
        {
            var affectedResult = await _postService.Delete(postID);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PostCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var postId = await _postService.Create(request);
            if (postId == 0)
                return BadRequest();
            var post = await _postService.GetPostById(postId);
            return CreatedAtAction(nameof(GetPostById), new { id = postId }, post);
           
        }
    }
}
