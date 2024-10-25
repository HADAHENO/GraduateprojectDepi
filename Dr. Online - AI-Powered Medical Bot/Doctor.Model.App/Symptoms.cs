using Doctor.Model.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Doctor.Model.App
{
    [Table("Symptoms")]
    public class Symptoms
    {
        public int SymptomsID { get; set; }
        public string SymptomsName { get; set; }
        public string SymptomsDescription { get; set; }
        public DateTime DateTime { get; set; }


      }
}
