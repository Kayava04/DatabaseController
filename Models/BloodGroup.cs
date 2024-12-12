using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class BloodGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BloodGroupID { get; set; }
        [MaxLength(10), Required]
        public string BloodGroupName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}