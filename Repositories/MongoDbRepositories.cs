using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContactManagement.Repositories
{


    public class MongoDbRepositories : IContactRepositories
    {
        private const string databaseName = "contactmanager";
        private const string collectionName = "contacts";
        private readonly IMongoCollection<Contact> contactCollection;
        private readonly FilterDefinitionBuilder<Contact> contactFilterBuilder = Builders<Contact>.Filter;

        public MongoDbRepositories(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            contactCollection = database.GetCollection<Contact>(collectionName);
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await contactCollection.InsertOneAsync(contact);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var filter = contactFilterBuilder.Eq(contact => contact.Id, id);
            await contactCollection.DeleteOneAsync(filter);    
        }

        public async Task<Contact> GetContactAsync(Guid id)
        {
            var filter = contactFilterBuilder.Eq(contact => contact.Id, id);
            return await contactCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(int PageNumber, int PageSize)
        {
            return await contactCollection
            .Find(new BsonDocument())
            .SortBy(contact => contact.LastName)
            .Skip((PageNumber-1) * PageSize)
            .Limit(PageSize)
            .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname, int PageNumber, int PageSize)
        {
            var filter = contactFilterBuilder
            .Eq(contact => contact.FirstName, firstname) & contactFilterBuilder.Eq(contact => contact.LastName, lastname);
            return await contactCollection.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<Contact>> SearchContactsAsync(string query, int PageNumber, int PageSize)
        {
            var filter = contactFilterBuilder
            .Eq(contact => contact.FirstName, query) | contactFilterBuilder.Eq(contact => contact.LastName, query);
            return await contactCollection.Find(filter).ToListAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            var filter = contactFilterBuilder.Eq(existingContact => existingContact.Id, contact.Id);
            await contactCollection.ReplaceOneAsync(filter, contact);
        }
    }
} 