using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Comments
{
    public class GetCommentPagingByProductId : PagingRequestBase
    {
        public int ProductId { get; set; }
    }
}
