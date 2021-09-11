namespace ContactManagement.Dtos
{
    public record SearchContactDto
    {
        public string FirstName {set; get;}

        public string LastName{set; get;}
        
        public string Email{set; get;}
        public string MobineNumber{set; get;}
    }
}