using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Contacts
{
    public class GetContactPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }

    }
}
