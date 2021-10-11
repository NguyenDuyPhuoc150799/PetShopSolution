using Microsoft.EntityFrameworkCore;
using PetShopSolution.Data.EF;
using PetShopSolution.Data.Entities;
using PetShopSolution.ViewModels.Sale.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Sale.Carts
{
    public class CartService : ICartService
    {
        private readonly PetShopDbContext _context;
        public CartService(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddItemFromCart(CartUpdateQuantityRequest request)
        {
            var user = await _context.AppUsers.FindAsync(request.UserId);
            if (user == null) throw new Exception($"User with id {request.UserId} not found");
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null) throw new Exception($"Product with id {request.ProductId} not found");
            var query = from c in _context.Carts
                        where c.UserId == request.UserId && c.ProductId == request.ProductId
                        select new { c };
           
            if (query.Count() == 0)
            {
                var data = new Cart()
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    Price = product.Price * request.Quantity,
                    UserId = request.UserId,
                    DateCreated = DateTime.Now,
                };
                _context.Carts.Add(data);
            }
            else
            {
                var cart = await query.Select(x => new Cart()
                {
                    Id = x.c.Id,
                    ProductId = x.c.ProductId,
                    Quantity = x.c.Quantity,
                    Price = x.c.Price
                }).FirstOrDefaultAsync();
                cart.Quantity += request.Quantity;
                cart.Price = product.Price * cart.Quantity;
            }
            product.Stock -= request.Quantity;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(CartCreateRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if(product == null) throw new Exception($"Product doesn't exist");
            if(request.Quantity >= product.Stock) throw new Exception($"Stock has run out");
            var cart = new Cart()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = product.Price * request.Quantity,
                UserId = request.UserId,
                DateCreated = DateTime.Now,              
            };
            product.Stock -= request.Quantity;
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart.Id;
        }

        public async Task<int> DeleteByUserId(Guid userId)
        {
            var carts = _context.Carts.Where(x => x.UserId == userId);
            foreach (var item in carts)
            {
                _context.Carts.Remove(item);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteItemFromCart(CartUpdateQuantityRequest request)
        {
            var user = await _context.AppUsers.FindAsync(request.UserId);
            if (user == null) throw new Exception($"User with id {request.UserId} not found");
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null) throw new Exception($"Product with id {request.ProductId} not found");
            var query = from c in _context.Carts
                        where c.UserId == request.UserId && c.ProductId == request.ProductId
                        select new { c };
            if(query.Count() == 0)
            {
                throw new Exception($"Product with id {request.ProductId} not in the cart");
            }
            var cart = await query.Select(x => new Cart()
            {
                Id = x.c.Id,
                ProductId = x.c.ProductId,
                Quantity = x.c.Quantity,
                Price = x.c.Price,
                DateCreated = x.c.DateCreated

            }).FirstOrDefaultAsync();
            
            if(cart.Quantity <= 1)
            {
                _context.Carts.Remove(cart);
            }
            else
            {
                cart.Quantity -= request.Quantity;
                cart.Price = product.Price * cart.Quantity;
            }
            product.Stock += request.Quantity;
            return await _context.SaveChangesAsync();


        }

        public async Task<List<CartViewModel>> GetAllByUserId(Guid userId,string languageId)
        {
            var query = from c in _context.Carts
                        join p in _context.Products on c.ProductId equals p.Id
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        where c.UserId == userId && pt.LanguageId == languageId
                        select new { c, p ,pt};
            var data = await query
                .Select(x => new CartViewModel()
                {
                    Id = x.c.Id,
                    ProductId = x.c.ProductId,
                    ProductName = x.pt.Name,
                    Quantity = x.c.Quantity,
                    Price = x.c.Quantity * x.p.Price,
                    DateCreated = x.c.DateCreated,                                  
                }).ToListAsync();

            return data;
        }

        public async Task<CartViewModel> GetById(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null) throw new Exception($"Cannot find a cart: {id}");
            var product = await _context.Products.FindAsync(cart.ProductId);
            var productTranslation = await _context.ProductTranslations.FindAsync(product.Id);
            var result = new CartViewModel()
            {
               Id =cart.Id,
               ProductId = cart.ProductId,
               Quantity = cart.Quantity,
               Price = product.Price * cart.Quantity,
               ProductName = productTranslation.Name,
               DateCreated = cart.DateCreated
            };
            return result;
        }
    }
}
