using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Sale.Carts
{
    public class CartUpdateQuantityRequest
    {
        public int ProductId { set; get; }
        public int Quantity { set; get; }    
        public Guid UserId { get; set; }
    }
}
