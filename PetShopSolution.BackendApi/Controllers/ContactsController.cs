using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopSolution.Application.Catalog.Contacts;
using PetShopSolution.ViewModels.Catalog.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetContactPagingRequest request)
        {
            var contacts = await _contactService.GetAllPaging(request);
            return Ok(contacts);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ContactCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contactId = await _contactService.Create(request);
            if (contactId == 0)
            {
                return BadRequest();
            }
            var contact = await _contactService.GetById(contactId);
            return CreatedAtAction(nameof(GetById), new { id = contactId }, contact);
        }
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetById(int ContactId)
        {
            var contact = await _contactService.GetById(ContactId);
            return Ok(contact);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] ContactUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectdResult = await _contactService.Update(request);
            if (affectdResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            var affectedResult = await _contactService.Delete(contactId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
      
    }
}
