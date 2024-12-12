using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class Diagnosis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DiagnosisID { get; set; }
        [Column(TypeName = "TEXT"), Required]
        public string DiagnosisText { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}