using PetShopSolution.ViewModels.Catalog.Posts;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Catalog.Posts
{
    public interface IPostService
    {
        Task<int> Create(PostCreateRequest request);
        Task<int> Update(PostUpdateRequest request);
        Task<int> Delete(int postID);
        Task<PagedResult<PostViewModel>> GetAllPostByUserId(GetPostPagingByUserId request);

        Task<PostViewModel> GetPostById(int postID);
    }
}
