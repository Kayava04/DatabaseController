using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLab_2.Models
{
    public class PatientWorkplace
    {
        [Key]
        public long PatientID { get; set; }
        [Key]
        public long? WorkplaceID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        [ForeignKey("WorkplaceID")]
        public Workplace Workplace { get; set; }
    }
}