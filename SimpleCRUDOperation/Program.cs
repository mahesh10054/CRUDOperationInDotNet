using Microsoft.EntityFrameworkCore;
using SimpleCRUDOperation.Models;

namespace SimpleCRUDOperation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EmployeeDbContext>(
                x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbConnections"))
            );

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee1}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
