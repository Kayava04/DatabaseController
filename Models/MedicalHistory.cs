using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class MedicalHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MedicalHistoryID { get; set; }
        [Required]
        public DateTime DiseaseStartDate { get; set; }
        [Required]
        public long DiseaseID { get; set; }
        [ForeignKey("DiseaseID")]
        public Disease Disease { get; set; }
    }
}