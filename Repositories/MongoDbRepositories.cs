using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateContactAsync(Contact contact)
        {
            contactCollection.InsertOne(contact);
        }

        public void DeleteContactAsync(Guid id)
        {
            var filter = contactFilterBuilder.Eq(contact => contact.Id, id);
            contactCollection.DeleteOne(filter);    
        }

        public Contact GetContactAsync(Guid id)
        {
            var filter = contactFilterBuilder.Eq(contact => contact.Id, id);
            return contactCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Contact> GetContactsAsync()
        {
            return contactCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateContactAsync(Contact contact)
        {
            var filter = contactFilterBuilder.Eq(existingContact => existingContact.Id, contact.Id);
            contactCollection.ReplaceOne(filter, contact);
        }
    }
} 