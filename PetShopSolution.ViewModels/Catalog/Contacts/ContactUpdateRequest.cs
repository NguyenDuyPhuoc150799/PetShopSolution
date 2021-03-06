using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Contacts
{
    public class ContactUpdateRequest
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; }
    }
}
