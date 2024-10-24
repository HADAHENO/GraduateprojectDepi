using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctor.Model;
using Doctor.Model.App;
namespace Doctor.Business
{
   

        public interface IUserRepository : IRepository<ApplicationUser>
        {
        ApplicationUser GetUserByUsername(string username);  
        }
    }



