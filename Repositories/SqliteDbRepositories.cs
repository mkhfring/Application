using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManagement.Entities;

namespace ContactManagement.Repositories
{
    public class SqliteDbRepositories : IContactRepositories
    {
        public Task CreateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetContactsAsync()
        {
            throw new NotImplementedException();
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