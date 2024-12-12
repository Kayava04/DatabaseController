using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class CityType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CityTypeID { get; set; }
        [MaxLength(50), Required]
        public string TypeName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}