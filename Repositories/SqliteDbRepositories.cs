using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.database;
using ContactManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Repositories
{
    public class SqliteDbRepositories : IContactRepositories
    {
        private readonly ContactContext context;
        public SqliteDbRepositories(ContactContext context)
        {
            this.context = context;
        }
        public async Task CreateContactAsync(Contact contact)
        {
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var existingContact = await context.Contacts.FindAsync(id);
            context.Remove(existingContact);
            await context.SaveChangesAsync();
        }

        public async Task<Contact> GetContactAsync(Guid id)
        {
            return await context.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await context.Contacts.OrderBy(a => a.LastName).ToListAsync();
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            var existingContact = await context.Contacts.FindAsync(contact.Id);
            var props = typeof(Contact).GetProperties();
            foreach(var prop in props){
                var value = prop.GetValue(contact);
                // if (value is null){
                //     continue;
                // }
                prop.SetValue(existingContact, value);
            }
            await context.SaveChangesAsync();
        }
    }
}