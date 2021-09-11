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
                MobineNumber="12345" 
                },
            new Contact {
                Id = Guid.NewGuid(),
                FirstName = "Ali", 
                LastName = "Khajezade" ,
                Email="examle1@example.com",
                MobineNumber="12345"
                },
            new Contact { 
                Id = Guid.NewGuid(),
                FirstName = "Saman", 
                LastName = "Khajezade",
                Email="examle2@example.com",
                MobineNumber="12345"
                }

        };
        public IEnumerable<Contact> GetContactsAsync()
        {
            return ContactList;
        }
        
        public Contact GetContactAsync(Guid id)
        {
            return ContactList.Where(Contact => Contact.Id == id).SingleOrDefault();
        }

        public void CreateContactAsync(Contact contact)
        {
            ContactList.Add(contact);
        }

        public void UpdateContactAsync(Contact contact){
            var index = ContactList.FindIndex(existingContact => existingContact.Id == contact.Id);
            ContactList[index] = contact;
        }
        
        public void DeleteContactAsync(Guid id){
            var index = ContactList.FindIndex(contact => contact.Id == id);
            ContactList.RemoveAt(index);
        }
    }
} 