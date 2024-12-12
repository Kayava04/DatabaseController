using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class PatientEducationPlace
    {
        [Key]
        public long PatientID { get; set; }
        [Key]
        public long? EducationPlaceID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        [ForeignKey("EducationPlaceID")]
        public EducationPlace EducationPlace { get; set; }
    }
}