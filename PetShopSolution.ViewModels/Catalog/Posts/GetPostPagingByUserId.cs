using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Posts
{
   public class GetPostPagingByUserId : PagingRequestBase
    {
        public Guid userId { get; set; }
    }
}
