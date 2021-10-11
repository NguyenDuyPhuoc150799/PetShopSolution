
using Microsoft.EntityFrameworkCore;
using PetShopSolution.Data.EF;
using PetShopSolution.Data.Entities;
using PetShopSolution.Data.Enum;
using PetShopSolution.ViewModels.Sale.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Sale.Orders
{
    public class OrderService : IOrderService
    {
        private readonly PetShopDbContext _context;
      
        public OrderService(PetShopDbContext context)
        {
            _context = context;
         
        }
        public async Task<int> Create(OrderCreateRequest request)
        {
            var user = await _context.AppUsers.FindAsync(request.UserId);
            if (user == null) throw new Exception($"User not found");
            var order = new Order()
            {
                UserId = request.UserId,
                ShipName = request.ShipName,
                ShipPhoneNumber = request.ShipPhoneNumber,
                ShipEmail = request.ShipEmail,
                ShipAddress = request.ShipAddress,
                Status = OrderStatus.InProgress,
                OrderDate = DateTime.Now,
                Total = 0,
            };      
            var cartItems = _context.Carts.Where(c => c.UserId == request.UserId).ToList();
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                order.Total += item.Price;
                orderDetails.Add(orderDetail);
            }
            _context.Orders.Add(order);
            _context.Carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Delete(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return 0;
            _context.Remove(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteByUserId(Guid userId)
        {
            var order = await _context.Orders.FindAsync(userId);
            if (order == null) return 0;
            _context.Remove(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderViewModel>> GetAllByUserId(Guid userId)
        {
            var query = from o in _context.Orders
                        where o.UserId == userId
                        select o;
            var data = await query
                .Select(x => new OrderViewModel()
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                UserId = x.UserId,
                ShipAddress = x.ShipAddress,
                ShipEmail = x.ShipEmail,
                ShipName = x.ShipName,
                ShipPhoneNumber = x.ShipPhoneNumber,
                Status = x.Status,
                Total = x.Total,
            }).ToListAsync();
            return data;
        }

        public async Task<OrderViewModel> GetById(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new Exception($"Order with id {orderId} doesn't exist");
            var result = new OrderViewModel()
            {
                Id =order.Id,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                ShipAddress = order.ShipAddress,
                ShipEmail=order.ShipEmail,
                ShipName=order.ShipName,
                ShipPhoneNumber= order.ShipPhoneNumber,
                Status = order.Status,
                Total = order.Total,
            };
            return result;
        }

        public async Task<int> UpdateStatus(OrderStatus request, int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return 0;        
            order.Status = request;
            return await _context.SaveChangesAsync();
        }
    }
}
