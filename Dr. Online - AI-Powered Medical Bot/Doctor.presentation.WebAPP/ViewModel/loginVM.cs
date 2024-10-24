using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Doctor.presentation.WebAPP.ViewModel
{
    public class loginVM
    {
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
