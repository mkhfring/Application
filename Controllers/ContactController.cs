using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Dtos;
using ContactManagement.Entities;
using ContactManagement.Repositories;
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
        public async Task<IEnumerable<ContactDto>> GetContactsAsync(){
            var contacts = (await repository.GetContactsAsync()).Select(contact => contact.AsDto());

            return contacts;
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
                MobileNumber = contactdto.MobileNumber,
                Email = contactdto.MobileNumber,
                HomePhoneNumber = contactdto.HomePhoneNumber,
                BussinessPhoneNumber = contactdto.BussinessPhoneNumber
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
                FirstName = updateDto.FirstName,
                LastName = updateDto.LastName,
                Email = updateDto.Email
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