using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Sale.Orders
{
    public class OrderCreateRequest
    {
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
    }
}
