using PetShopSolution.ViewModels.Catalog.Comments;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Catalog.Comments
{
   public interface ICommentService
    {
        Task<int> Create(CommentCreateRequest request);
        Task<int> Update(CommentUpdateRequest request);
        Task<int> Delete(int commentId);

        Task<int> Delete(Guid userId);

        Task<PagedResult<CommentViewModel>> GetAllByProductId(GetCommentPagingByProductId request);

        Task<PagedResult<CommentViewModel>> GetAllByUserId(GetCommentPagingByUserId request);
        Task<CommentViewModel> GetById(int commentId);
    }
}
