using System;
using System.Collections.Generic;
using ContactManagement.Dtos;
using ContactManagement.Entities;
using ContactManagement.Response;

namespace ContactManagement
{
    public static class Extensions
    {
        public static ContactDto AsDto(this Contact contact){
            return new ContactDto{
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MobilePhoneNumber = contact.MobilePhoneNumber,
                HomePhoneNumber = contact.HomePhoneNumber,
                BusinessPhoneNumber = contact.BusinessPhoneNumber
            };
        }
        public static ContactListResponse AsContactListReponse (this IEnumerable<ContactDto> contactList, int ContactNumber){

            return new ContactListResponse {
                ContactList = contactList,
                TotalNumber = ContactNumber
            };

        }
        
    }
}