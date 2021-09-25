using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopSolution.Application.Catalog.Comments;
using PetShopSolution.ViewModels.Catalog.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetAllByProductId([FromQuery] GetCommentPagingByProductId request)
        {
            var comments = await _commentService.GetAllByProductId(request);
            return Ok(comments);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAllByUserId([FromQuery] GetCommentPagingByUserId request)
        {
            var comments = await _commentService.GetAllByUserId(request);
            return Ok(comments);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CommentCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentId = await _commentService.Create(request);
            if (commentId == 0)
            {
                return BadRequest();
            }
            var comment = await _commentService.GetById(commentId);
            return CreatedAtAction(nameof(GetById), new { id = commentId }, comment);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int commentId)
        {
            var comment = await _commentService.GetById(commentId);
            return Ok(comment);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] CommentUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectdResult = await _commentService.Update(request);
            if (affectdResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(int commentId)
        {
            var affectedResult = await _commentService.Delete(commentId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var affectedResult = await _commentService.Delete(userId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
