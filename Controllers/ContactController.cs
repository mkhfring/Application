using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Dtos;
using ContactManagement.Entities;
using ContactManagement.Repositories;
using ContactManagement.Response;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepositories repository;
        public ContactController(IContactRepositories repository)
             
        {
            this.repository = repository;
            
        }

        [HttpGet]
        public async Task<ContactListResponse> GetContactsAsync(int PageNumber=1, int PageSize=50){
            
            var contacts = (await repository.GetContactsAsync(PageNumber, PageSize)).Select(contact => contact.AsDto());

            return contacts.AsContactListReponse(await repository.TotalRecordsAsync());
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetContactAsync(Guid id){
            var contact = await repository.GetContactAsync(id);

            if (contact is null){
                return NotFound();
            }
            return contact.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>> CreateContactAsync(CreateDto contactdto){
            Contact newContact = new(){
                Id = Guid.NewGuid(),
                FirstName = contactdto.FirstName,
                LastName = contactdto.LastName,
                MobilePhoneNumber = contactdto.MobilePhoneNumber,
                Email = contactdto.Email,
                HomePhoneNumber = contactdto.HomePhoneNumber,
                BusinessPhoneNumber = contactdto.BusinessPhoneNumber
            };
            await repository.CreateContactAsync(newContact);
            return  newContact.AsDto();
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContactAsync(Guid id, UpdateContactDto updateDto){
            var existingContact = await repository.GetContactAsync(id);
            if(existingContact is null){
                return NotFound();
            }
            Contact updateContact = existingContact with{
                FirstName = updateDto.FirstName is null ? existingContact.FirstName: updateDto.FirstName,
                LastName = updateDto.LastName is null ? existingContact.LastName: updateDto.LastName,
                Email = updateDto.Email is null ? existingContact.Email: updateDto.Email,
                MobilePhoneNumber = updateDto.MobilePhoneNumber is null ? existingContact.MobilePhoneNumber: updateDto.MobilePhoneNumber,
                HomePhoneNumber = updateDto.HomePhoneNumber is null ? existingContact.HomePhoneNumber: updateDto.HomePhoneNumber,
                BusinessPhoneNumber = updateDto.BusinessPhoneNumber is null ? existingContact.BusinessPhoneNumber: updateDto.BusinessPhoneNumber
            };
            await repository.UpdateContactAsync(updateContact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id){
            Contact existingContact = await repository.GetContactAsync(id);
            if (existingContact is null){
                return NotFound();
            }

            await repository.DeleteContactAsync(id);
            return NoContent();
        }
     
    }
}