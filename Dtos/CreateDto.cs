using System.ComponentModel.DataAnnotations;
namespace ContactManagement.Dtos
{
    public class CreateDto
    {
        [Required]
        [Range(3, 50)]
        public string FirstName {set; get;}

        [Required]
        [Range(3, 50)]
        public string LastName{set; get;}
        
        public string Email{set; get;}
        public int MobineNumber{set; get;}
    }
}