﻿using PetShopSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Sale.Orders
{
    public class OrderViewModel
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        public decimal Total { get; set; }
    }
}
