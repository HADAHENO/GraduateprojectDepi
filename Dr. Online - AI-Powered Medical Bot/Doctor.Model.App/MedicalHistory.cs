using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctor.Model.App
{
    [Table("MedicalHistory") ]
    public class MedicalHistory
    {
        [Required]
        public int HistoryId { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public string Sympotoms { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }

    }
}
