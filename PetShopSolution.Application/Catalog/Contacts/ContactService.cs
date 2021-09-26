using PetShopSolution.Data.EF;
using PetShopSolution.Data.Entities;
using PetShopSolution.ViewModels.Catalog.Contacts;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PetShopSolution.Application.Catalog.Contacts
{
    public class ContactService : IContactService
    {
        private readonly PetShopDbContext _context;
        public ContactService(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ContactCreateRequest request)
        {
            var contact = new Contact() 
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Message = request.Message,
                Status = request.Status
            };
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact.Id;
        }

        public async Task<int> Delete(int ContactId)
        {
            var contact = await _context.Contacts.FindAsync(ContactId);
            if (contact == null) throw new Exception($"Cannot find a contact: {ContactId}");
            _context.Contacts.Remove(contact);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ContactViewModel>> GetAllPaging(GetContactPagingRequest request)
        {
            var query = from c in _context.Contacts
                        select c;
            // filter
            if (!string.IsNullOrEmpty(request.KeyWord))
                query = query.Where(x => x.Name.Contains(request.KeyWord) || x.Email.Contains(request.KeyWord)|| x.PhoneNumber.Contains(request.KeyWord));
            // paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ContactViewModel()
                {
                  Id = x.Id,
                  Name = x.Name,
                  Email = x.Email,
                  PhoneNumber = x.PhoneNumber,
                  Message = x.Message,
                  Status = x.Status
                }).ToListAsync();
            // select and projection
            var pageResult = new PagedResult<ContactViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pageResult;
        }

        public async Task<ContactViewModel> GetById(int ContactId)
        {
            var contact = await _context.Contacts.FindAsync(ContactId);
            if (contact == null) throw new Exception($"Cannot find a contact: {ContactId}");

            var result = new ContactViewModel()
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
                Status = contact.Status
            };
            return result;
        }

        public async Task<int> Update(ContactUpdateRequest request)
        {
            var contact = await _context.Contacts.FindAsync(request.Id);
            if (contact == null) throw new Exception($"Cannot find a contact: {request.Id}");

            if (!string.IsNullOrEmpty(request.Name))
                contact.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Email))
                contact.Email = request.Email;
            if (!string.IsNullOrEmpty(request.PhoneNumber))
                contact.PhoneNumber = request.PhoneNumber;
            if (!string.IsNullOrEmpty(request.Message))
                contact.Message = request.Message;
            return await _context.SaveChangesAsync();
            
           
        }
    }
}
