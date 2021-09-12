
using ContactManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.database
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) :base(options)
        {
            Database.EnsureCreated();
            
        }
        public DbSet<Contact> Contacts{set; get;}
    }
}