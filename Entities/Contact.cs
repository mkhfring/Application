using System;

namespace ContactManagement.Entities
{
    public record Contact
    {
        public Guid Id {set; get;}
        public string FirstName {set; get;}
        public string LastName{set; get;}
        public string Email {set; get;}
        public string MobilePhoneNumber {set; get;}
        
        public string HomePhoneNumber {set; get;}
        public string BusinessPhoneNumber {set; get;}
    }
}