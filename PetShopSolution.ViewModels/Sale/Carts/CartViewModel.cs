using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Sale.Carts
{
    public class CartViewModel
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string ProductName { get; set; }
   //     public decimal Total { set; get; }
        public DateTime DateCreated { get; set; }
      //  public Guid UserId { get; set; }
      //  public string LanguageId { get; set; }
    }
}
