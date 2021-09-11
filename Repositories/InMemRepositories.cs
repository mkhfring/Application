using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                MobileNumber="12345" 
                },
            new Contact {
                Id = Guid.NewGuid(),
                FirstName = "Ali", 
                LastName = "Khajezade" ,
                Email="examle1@example.com",
                MobileNumber="12345"
                },
            new Contact { 
                Id = Guid.NewGuid(),
                FirstName = "Saman", 
                LastName = "Khajezade",
                Email="examle2@example.com",
                MobileNumber="12345"
                }

        };
        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await Task.FromResult(ContactList);
        }
        
        public async Task<Contact> GetContactAsync(Guid id)
        {
            var contact =  ContactList.Where(Contact => Contact.Id == id).SingleOrDefault();
            return await Task.FromResult(contact);
        }

        public async Task CreateContactAsync(Contact contact)
        {
            ContactList.Add(contact);
            await Task.CompletedTask;
        }

        public async Task UpdateContactAsync(Contact contact){
            var index = ContactList.FindIndex(existingContact => existingContact.Id == contact.Id);
            ContactList[index] = contact;
            await Task.CompletedTask;
        }
        
        public async Task DeleteContactAsync(Guid id){
            var index = ContactList.FindIndex(contact => contact.Id == id);
            ContactList.RemoveAt(index);
            await Task.CompletedTask;
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string FirstName)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Contact>> SearchContactsAsync(string FirstName, string lastname)
        {
            throw new NotImplementedException();
        }
    }
} 