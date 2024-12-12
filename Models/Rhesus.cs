using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Rhesus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RhesusID { get; set; }
        [MaxLength(15), Required]
        public string RhesusName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}