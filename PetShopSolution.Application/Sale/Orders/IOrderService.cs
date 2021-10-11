using PetShopSolution.Data.Enum;
using PetShopSolution.ViewModels.Sale.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Sale.Orders
{
    public interface IOrderService
    {
        Task<int> Create(OrderCreateRequest request);
        Task<int> Delete(int orderId);
        Task<int> DeleteByUserId(Guid userId);
        Task<int> UpdateStatus(OrderStatus request,int orderId);
        Task<OrderViewModel> GetById(int orderId);
        Task<List<OrderViewModel>> GetAllByUserId(Guid userId);
    }
}
