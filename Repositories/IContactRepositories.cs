using System;
using System.Collections.Generic;
using ContactManagement.Entities;

namespace ContactManagement.Repositories
{
    public interface IContactRepositories
    {
        Contact GetContact(Guid id);
        IEnumerable<Contact> GetContacts();

        void CreateContact(Contact contact);

        void UpdateContact(Contact contact);
    }
}