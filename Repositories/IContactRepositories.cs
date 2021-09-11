using System;
using System.Collections.Generic;
using ContactManagement.Entities;

namespace ContactManagement.Repositories
{
    public interface IContactRepositories
    {
        Contact GetContactAsync(Guid id);
        IEnumerable<Contact> GetContactsAsync();

        void CreateContactAsync(Contact contact);

        void UpdateContactAsync(Contact contact);

        void DeleteContactAsync(Guid id);
    }
}