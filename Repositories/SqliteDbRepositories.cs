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

        public async Task<IEnumerable<Contact>> GetContactsAsync(int PageNumber, int PageSize)
        {
            return await context.Contacts
            .OrderBy(a => a.LastName)
            .Skip((PageNumber-1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname, int PageNumber, int PageSize)
        {
            return await context.Contacts
            .Where(Contact=> Contact.FirstName.ToLower() == firstname.ToLower() && Contact.LastName.ToLower() == lastname.ToLower())
            .Skip((PageNumber -1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string query, int PageNumber, int PageSize)
        {
            return await context.Contacts
            .Where(Contact=> Contact.FirstName.ToLower() == query.ToLower() || Contact.LastName.ToLower() == query.ToLower())
            .Skip((PageNumber -1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

        public async Task<int> TotalRecordsAsync()
        {
            return await Task.FromResult(context.Contacts.Count());
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