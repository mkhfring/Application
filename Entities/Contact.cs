using System;

namespace ContactManagement.Entities
{
    public class Contact
    {
        public Guid Id {set; get;}
        public string FirstName {set; get;}
        public string LastName{set; get;}
        public string Email {set; get;}
        public int HomePhoneNumber {set; get;}
        public int BussinessPhoneNumber {set; get;}
        public int MobineNumber {set; get;}
    }
}