using System;
using ContactManagement.Dtos;
using ContactManagement.Entities;

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
                MobineNumber = contact.MobineNumber
            };
        }
        
    }
}