using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopSolution.Application.Catalog.Newss;
using PetShopSolution.ViewModels.Catalog.Newss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewssController : ControllerBase
    {
        private readonly INewsSerivce _newsService;
        public NewssController(INewsSerivce newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetAllNewsPagingRequest request)
        {
            var news = await _newsService.GetAllPaging(request);
            return Ok(news);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NewsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newsId = await _newsService.Create(request);
            if (newsId == 0)
            {
                return BadRequest();
            }
            var news = await _newsService.GetById(newsId);
            return CreatedAtAction(nameof(GetById), new { id = newsId }, news);
        }
        [HttpGet("{newsId}")]
        public async Task<IActionResult> GetById(int newsId)
        {
            var news = await _newsService.GetById(newsId);
            return Ok(news);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] NewsUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectdResult = await _newsService.Update(request);
            if (affectdResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{newsId}")]
        public async Task<IActionResult> Delete(int newsId)
        {
            var affectedResult = await _newsService.Delete(newsId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
