using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Speciality
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SpecialityID { get; set; }
        [MaxLength(50), Required]
        public string SpecialityName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}