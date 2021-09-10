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
            new Contact { 
                Id = Guid.NewGuid(), 
                FirstName = "Mohamad",
                LastName = "Khajezade",
                Email="examle@example.com",
                MobineNumber=12345 
                },
            new Contact {
                Id = Guid.NewGuid(),
                FirstName = "Ali", 
                LastName = "Khajezade" ,
                Email="examle1@example.com",
                MobineNumber=12345
                },
            new Contact { 
                Id = Guid.NewGuid(),
                FirstName = "Saman", 
                LastName = "Khajezade",
                Email="examle2@example.com",
                MobineNumber=12345
                }

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
        
        public void UpdateContact(Contact contact){
            var index = ContactList.FindIndex(existingContact => existingContact.Id == contact.Id);
            ContactList[index] = contact;
        }
    }
} 