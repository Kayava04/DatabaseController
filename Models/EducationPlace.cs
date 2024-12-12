using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class EducationPlace
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EducationPlaceID { get; set; }
        [MaxLength(100), Required]
        public string OrganizationName { get; set; }
        [Required]
        public long AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
        public virtual ICollection<EducationPlacePhone> EducationPlacePhones { get; set; }
    }
}