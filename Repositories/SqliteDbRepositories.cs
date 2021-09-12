using System;
using System.Collections.Generic;
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

        public Task DeleteContactAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task UpdateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}