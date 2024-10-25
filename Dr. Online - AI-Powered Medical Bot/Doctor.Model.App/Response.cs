using Doctor.Model.App;
using System;
 using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Model.App
{
    [Table("Response")]
    public class Response
    {
        public int ResponseID { get; set; }
        public string ResponseText { get; set; }

        // Each response is linked to one symptom
        [ForeignKey("SymptomsID")]
        public int SymptomsID { get; set; }
        public Symptoms Symptoms { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
}


