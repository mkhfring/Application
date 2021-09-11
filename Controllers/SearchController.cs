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
        public async Task<IEnumerable<Contact>> SearchContactAsync(string firstname){

            var contacts = await repository.SearchContactsAsync(firstname);

            return contacts;
        } 


     
    }
}