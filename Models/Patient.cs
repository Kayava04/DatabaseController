using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PatientID { get; set; }
        [Required]
        public long PersonID { get; set; }
        [Required]
        public long AddressID { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(20), Required]
        public string MedicalCardNumber { get; set; }
        [Required]
        public long BloodGroupID { get; set; }
        [Required]
        public long RhesusID { get; set; }
        [Required]
        public bool IsWorking { get; set; }
        [Required]
        public bool IsStudying { get; set; }
        public long? MedicalHistoryID { get; set; }
        public long? FamilyDoctorID { get; set; }
        [ForeignKey("PersonID")]
        public Person Person { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
        [ForeignKey("BloodGroupID")]
        public BloodGroup BloodGroup { get; set; }
        [ForeignKey("RhesusID")]
        public Rhesus Rhesus { get; set; }
        [ForeignKey("MedicalHistoryID")]
        public MedicalHistory MedicalHistory { get; set; }
        [ForeignKey("FamilyDoctorID")]
        public Employee FamilyDoctor { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
        public virtual ICollection<EducationPlace> EducationPlaces { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}