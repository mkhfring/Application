namespace ContactManagement.Dtos
{
    public record UpdateContactDto
    {
        public string FirstName {set; get;}

        public string LastName{set; get;}
       
        public string Email{set; get;}
        public string MobilePhoneNumber{set; get;}
        public string HomePhoneNumber {set; get;}
        public string BusinessPhoneNumber {set; get;}

    }
}