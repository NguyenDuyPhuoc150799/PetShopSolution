using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Sale.Carts
{
    public class CartCreateRequest
    {
        public int ProductId { set; get; } 
        public int Quantity { set; get; } 
        public decimal Price { set; get; } 
        public Guid UserId { get; set; } 
    }
}
