using System;

namespace ContactManagement.Dtos
{
    public record ContactDto
    {
        
        public Guid Id {set; get;}
        public string FirstName {set; get;}
        public string LastName{set; get;}
        public string Email {set; get;}
        public string HomePhoneNumber {set; get;}
        public string BussinessPhoneNumber {set; get;}
        public string MobineNumber {set; get;}
    }
}