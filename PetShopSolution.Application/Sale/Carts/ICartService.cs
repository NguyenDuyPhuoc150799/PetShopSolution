using PetShopSolution.ViewModels.Sale.Carts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Sale.Carts
{
    public interface ICartService
    {
        Task<int> Create(CartCreateRequest request);
       // Task<int> Update(CartUpdateQuantityRequest request);
        //Task<int> Delete(int CartId);
        Task<int> DeleteByUserId(Guid userId);
        //Task<CartViewModel> GetById(int cartId);
        Task<List<CartViewModel>> GetAllByUserId(Guid userId,string languageId);
        Task<int> DeleteItemFromCart(CartUpdateQuantityRequest request);
        Task<int> AddItemFromCart(CartUpdateQuantityRequest request);
        Task<CartViewModel> GetById(int id);
    }
}
