using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopSolution.Application.Sale.Orders;
using PetShopSolution.Data.Enum;
using PetShopSolution.ViewModels.Sale.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = await _orderService.Create(request);
            if (orderId == 0)
            {
                return BadRequest();
            }
            var order = await _orderService.GetById(orderId);
            return CreatedAtAction(nameof(GetById), new { id = orderId }, order);
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetById(id);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId)
        {
            var carts = await _orderService.GetAllByUserId(userId);
            return Ok(carts);
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteByUserId(Guid userId)
        {
            var affectedResult = await _orderService.DeleteByUserId(userId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var affectedResult = await _orderService.Delete(orderId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
          [HttpPut]
        public async Task<IActionResult> UpdateStatus(OrderStatus request, int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _orderService.UpdateStatus(request,orderId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
