using System.Collections.Generic;
using ContactManagement.Dtos;
using ContactManagement.Entities;

namespace ContactManagement.Response
{
    public class ContactListResponse
    {
        public IEnumerable<ContactDto> ContactList{set; get;}
        public int TotalNumber {set; get;}
    }
}