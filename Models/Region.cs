using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RegionID { get; set; }
        [MaxLength(50), Required]
        public string RegionName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}