using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Model.App
{
    public enum Gender
    {
        male = 0, female = 1,
    }
    public class ApplicationUser : IdentityUser<int>
    {
         public int iduser;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? Role { get; set; }
    }
}
