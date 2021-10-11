using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopSolution.Application.Sale.Carts;
using PetShopSolution.ViewModels.Sale.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId, string languageId)
        {
            var carts = await _cartService.GetAllByUserId(userId, languageId);
            return Ok(carts);
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteByUserId(Guid userId)
        {
            var affectedResult = await _cartService.DeleteByUserId(userId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CartCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartId = await _cartService.Create(request);
            if (cartId == 0)
            {
                return BadRequest();
            }
            var cart = await _cartService.GetById(cartId);
            return CreatedAtAction(nameof(GetById), new { id = cartId }, cart);
        }
        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await _cartService.GetById(id);
            return Ok(cart);
        }
        [HttpPost("{addItem}")]
        public async Task<IActionResult> AddItemFromCart(CartUpdateQuantityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _cartService.AddItemFromCart(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> DeleteItemFromCart(CartUpdateQuantityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _cartService.DeleteItemFromCart(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }


    }
}
