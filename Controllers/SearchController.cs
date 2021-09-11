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
    [Route("/api/search")]
    public class SearchController : ControllerBase
    {
        private readonly IContactRepositories repository;
        public SearchController(IContactRepositories repository)
        {
            this.repository = repository;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> SearchContactAsync(string firstname, string lastname){

            if ((firstname is null) && (lastname is null)){
                return BadRequest("Both firstname and last name are empty");
                
            } 
            if ((firstname is null) && (lastname is not null)){
                var contactsForLastname = await repository.SearchContactsAsync(lastname);
                return contactsForLastname.ToList();
            }
            if ((firstname is not null) && (lastname is null)){
                var contactsForFirstname = await repository.SearchContactsAsync(firstname);
                return contactsForFirstname.ToList();
            }

            var contacts = await repository.SearchContactsAsync(firstname, lastname);
            return contacts.ToList();
        } 


     
    }
}