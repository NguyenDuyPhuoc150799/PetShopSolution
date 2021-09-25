using PetShopSolution.ViewModels.Catalog.Newss;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Catalog.Newss
{
   public interface INewsSerivce
    {
        Task<int> Create(NewsCreateRequest request);
        Task<int> Update(NewsUpdateRequest request);
        Task<int> Delete(int newsId);
        Task<PagedResult<NewsViewModel>> GetAllPaging(GetAllNewsPagingRequest request);
        Task<NewsViewModel> GetById( int newsId);
    }
}
