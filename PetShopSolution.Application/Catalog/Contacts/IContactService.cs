using PetShopSolution.ViewModels.Catalog.Contacts;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Catalog.Contacts
{
    public interface IContactService
    {
        Task<int> Create(ContactCreateRequest request);
        Task<int> Delete(int ContactId);
        Task<ContactViewModel> GetById(int ContactId);
        Task<PagedResult<ContactViewModel>> GetAllPaging(GetContactPagingRequest request);
        Task<int> Update(ContactUpdateRequest request);
       
    }
}
