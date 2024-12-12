using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class EducationPlacePhone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EducationPlacePhoneID { get; set; }
        [Required]
        public long EducationPlaceID { get; set; }
        [MaxLength(15), Required]
        public string PhoneNumber { get; set; }
        [ForeignKey("EducationPlaceID")]
        public EducationPlace EducationPlace { get; set; }
    }
}