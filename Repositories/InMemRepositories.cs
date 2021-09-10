using System;
using System.Collections.Generic;
using System.Linq;
using ContactManagement.Entities;

namespace ContactManagement.Repositories
{


    public class InMemRepositories : IContactRepositories
    {
        private readonly List<Contact> ContactList = new()
        {
            new Contact { Id = Guid.NewGuid(), FirstName = "Mohamad", LastName = "Khajezade" },
            new Contact { Id = Guid.NewGuid(), FirstName = "Ali", LastName = "Khajezade" },
            new Contact { Id = Guid.NewGuid(), FirstName = "Saman", LastName = "Khajezade" }

        };
        public IEnumerable<Contact> GetContacts()
        {
            return ContactList;
        }
        public Contact GetContact(Guid id)
        {
            return ContactList.Where(Contact => Contact.Id == id).SingleOrDefault();
        }

        public void CreateContact(Contact contact)
        {
            ContactList.Add(contact);
        }
    }
} 