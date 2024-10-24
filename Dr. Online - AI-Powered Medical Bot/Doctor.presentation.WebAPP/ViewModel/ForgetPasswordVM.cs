using System.ComponentModel.DataAnnotations;

namespace Doctor.presentation.WebAPP.ViewModel
{
    public class ForgetPasswordVM
    {
        [Required]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
