using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class City
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CityID { get; set; }
        [MaxLength(50), Required]
        public string CityName { get; set; }
        [Required]
        public long CityTypeID { get; set; }
        [ForeignKey("CityTypeID")]
        public CityType CityType { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}