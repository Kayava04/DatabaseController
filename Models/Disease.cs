using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Disease
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DiseaseID { get; set; }
        [MaxLength(100), Required]
        public string DiseaseName { get; set; }
        [Required]
        public long DiagnosisID { get; set; }
        [ForeignKey("DiagnosisID")]
        public Diagnosis Diagnosis { get; set; }
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; }
    }
}