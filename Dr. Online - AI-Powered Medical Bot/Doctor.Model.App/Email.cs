using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Model.App
{

    public class Email
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string From { get; set; }




    }
}
