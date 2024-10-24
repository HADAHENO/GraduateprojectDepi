using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Doctor.Model.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Doctor.Data.APP
{
    public class DoctorContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {
        public DbSet<Response> Responses { get; set; }
    public DbSet<Symptoms> Symptoms { get; set; }
        public DoctorContext(DbContextOptions options) : base(options)
        {

        }

    }
}
