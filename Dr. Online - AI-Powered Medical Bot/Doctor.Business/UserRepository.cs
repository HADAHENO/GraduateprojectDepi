using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctor.Model;
using Doctor.Data;
using Doctor.Model.App;
using Doctor.Data.APP;


namespace Doctor.Business
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
        {
            public UserRepository(DoctorContext context) : base(context)
            {
            }

            public ApplicationUser GetUserByUsername(string username)
            {
                return _context.Users.FirstOrDefault(u => u.UserName == username);
            }
        }
    }


