using Blog.Web.Mvc.Data;

namespace Blog.Web.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                // Veritabaný servisine eriþim saðlar.
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                // Veritabanýný sil
                context.Database.EnsureDeleted();
                // Veritabanýný oluþturur
                context.Database.EnsureCreated();
            }

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}