using Doctor.Business;
using Doctor.Data.APP;
using Doctor.Model.App;
using Doctor.Presentation.WebApp.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Doctor.presentation.WebAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add SignalR service
            builder.Services.AddSignalR(); 

            // Add scoped services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRepositoryUserAdd, RepositoryUserAdd>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddScoped<UserService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Database context configuration
            builder.Services.AddDbContext<DoctorContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            // Identity configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(option =>
            {
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 3;
            })
           .AddEntityFrameworkStores<DoctorContext>()
           .AddDefaultTokenProviders();

            // Build the app
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Authentication and Authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Map SignalR hub
            app.MapHub<ChatHub>("/chathub");

            // Default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Run the app
            app.Run();
        }
    }
}
