using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeID { get; set; }
        [Required]
        public long PersonID { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public long SpecialityID { get; set; }
        [Required]
        public long DistrictID { get; set; }
        [ForeignKey("PersonID")]
        public Person Person { get; set; }
        [ForeignKey("SpecialityID")]
        public Speciality Speciality { get; set; }
        [ForeignKey("DistrictID")]
        public Address DistrictAddress { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}