using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class HouseNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long HouseNumberID { get; set; }
        [MaxLength(10), Required]
        public string House_Number { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}