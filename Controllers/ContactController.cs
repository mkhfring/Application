using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ContactDto> GetContacts(){
            var contacts = repository.GetContacts().Select(contact => contact.AsDto());

            return contacts;
        }

        [HttpGet("{id}")]
        public ActionResult<ContactDto> GetContact(Guid id){
            var contact = repository.GetContact(id);

            if (contact is null){
                return NotFound();
            }
            return contact.AsDto();
        }

        [HttpPost]
        public ActionResult<ContactDto> CreateContact(CreateDto contactdto){
            Contact newContact = new(){
                Id = Guid.NewGuid(),
                FirstName = contactdto.FirstName,
                LastName = contactdto.LastName
            };
            repository.CreateContact(newContact);
            return  newContact.AsDto();
           
        }
        [HttpPut("{id}")]
        public ActionResult UpdateContact(Guid id, UpdateContactDto updateDto){
            var existingContact = repository.GetContact(id);
            if(existingContact is null){
                return NotFound();
            }
            Contact updateContact = existingContact with{
                FirstName = updateDto.FirstName,
                LastName = updateDto.LastName
            };
            return NoContent();
        }
     
    }
}