using System.ComponentModel.DataAnnotations;
namespace ContactManagement.Dtos
{
    public record CreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName {set; get;}

        [Required]
        [MaxLength(50)]
        public string LastName{set; get;}

        [RegularExpression(
            @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid Email")
        ]
        public string Email{set; get;}
        
        [RegularExpression(
            @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Invalid Mobile Number")
        ]
        public string MobilePhoneNumber{set; get;}
        [RegularExpression(
            @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Invalid Home Phone Number")
        ]
        public string HomePhoneNumber {set; get;}
        [RegularExpression(
            @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Invalid Business Phone Number")
        ]        
        public string BusinessPhoneNumber {set; get;}
    }
}