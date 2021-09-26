using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Newss
{
    public class GetAllNewsPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
