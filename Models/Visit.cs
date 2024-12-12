using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Visit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VisitID { get; set; }
        [Required]
        public long PatientID { get; set; }
        [Required]
        public long EmployeeID { get; set; }
        [Required]
        public long DiagnosisID { get; set; }
        [Column(TypeName = "TEXT"), Required]
        public string ComplaintsText { get; set; }
        [Column(TypeName = "TEXT"), Required]
        public string RecommendationsText { get; set; }
        [Required]
        public DateTime VisitDateTime { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
        [ForeignKey("DiagnosisID")]
        public Diagnosis Diagnosis { get; set; }
    }
}