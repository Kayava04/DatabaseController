using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class WorkplacePhone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WorkplacePhoneID { get; set; }
        [Required]
        public long WorkplaceID { get; set; }
        [MaxLength(15), Required]
        public string PhoneNumber { get; set; }
        [ForeignKey("WorkplaceID")]
        public Workplace Workplace { get; set; }
    }
}