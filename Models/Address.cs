using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AddressID { get; set; }
        [Required]
        public long RegionID { get; set; }
        [Required]
        public long CityID { get; set; }
        [Required]
        public long StreetID { get; set; }
        [Required]
        public long HouseID { get; set; }
        [ForeignKey("RegionID")]
        public Region Region { get; set; }

        [ForeignKey("CityID")]
        public City City { get; set; }

        [ForeignKey("StreetID")]
        public Street Street { get; set; }

        [ForeignKey("HouseNumberID")]
        public HouseNumber HouseNumber { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}