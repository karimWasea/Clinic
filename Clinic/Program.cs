using Clincic.DataAccesslayer;

using Clinic.Abstract;
using Clinic.Service;

using Microsoft.EntityFrameworkCore;

namespace Clinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            IServiceCollection serviceCollection = builder.Services.AddDbContext<ApplicationDBcontext>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddTransient<lookupServess>();
            builder.Services.AddTransient<BaseServess>();
            builder.Services.AddTransient<DoctorServess>();
            builder.Services.AddTransient<ClinicServess>();
            builder.Services.AddTransient<PatienteServess>();
            builder.Services.AddTransient<DoctorServess>();
            builder.Services.AddTransient<SHiftsServess>();
            builder.Services.AddTransient<VisitServess>();
            builder.Services.AddTransient<DoctorShiftervess>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.MapControllerRoute(
            //name: "default",
            //pattern: "{controller=Home}/{action=Index}/{id?}");









            app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            //app.MapControllerRoute(
            //       name: "HR",
            //       pattern: "{area=Admin}/{controller=Employee}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
