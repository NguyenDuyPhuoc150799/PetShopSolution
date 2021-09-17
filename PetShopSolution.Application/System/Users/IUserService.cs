using PetShopSolution.ViewModels.Common;
using PetShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
        Task<bool> Update(Guid id, UserUpdateRequest request);

        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);

        Task<UserViewModel> GetById(Guid id);

        Task<bool> Delete(Guid id);

        Task<bool> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
