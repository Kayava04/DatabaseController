using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Street
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StreetID { get; set; }
        [MaxLength(50), Required]
        public string StreetName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}