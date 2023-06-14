using Blog.Business.Services;
using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Business
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>()/*(o =>
            {
                string connectionString = configuration.GetConnectionString("Default");
                o.UseSqlServer(connectionString);
            })*/;
			services.AddTransient<PostService>();
			services.AddTransient<CategoryService>();
			services.AddTransient<PageService>();
			services.AddTransient<SettingService>();
			services.AddTransient<UserService>();
			return services;
		}
		public static void EnsureDeletedAndCreated(IServiceScope scope)
		{
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			DbSeeder.Seed(context);
		}
	}
}
