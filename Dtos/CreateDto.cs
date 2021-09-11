using System.ComponentModel.DataAnnotations;
namespace ContactManagement.Dtos
{
    public record CreateDto
    {
        [Required]
        public string FirstName {set; get;}

        [Required]
        public string LastName{set; get;}
        
        public string Email{set; get;}
        public string MobileNumber{set; get;}
        public string HomePhoneNumber {set; get;}
        public string BussinessPhoneNumber {set; get;}
    }
}