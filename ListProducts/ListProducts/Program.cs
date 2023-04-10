using Microsoft.EntityFrameworkCore;
using Model.Models.Context;
using Model.Models.Repository;
using Model.Models.Repository.Interface;
using Services.Services;
using Services.Services.Interface;

namespace ListProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt => opt
                               .UseSqlServer(builder.Configuration.GetConnectionString("DBProductConnection")));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "deleteProduct",
                    pattern: "product/delete/{id?}",
                    defaults: new { controller = "Product", action = "DeleteProduct" });

                endpoints.MapControllerRoute(
                    name: "updateProduct",
                    pattern: "Product/UpdateProduct",
                    defaults: new { controller = "Product", action = "UpdateProduct" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}