using Blog.Data.Entity;

namespace Blog.Data
{
	public class DbSeeder
	{
		public static void Seed(AppDbContext context)
		{
			if (!context.Categories.Any())
			{
				var categories = new Category[]
				{
					new Category { Name = "Dünya", Slug = "dunya" },
					new Category { Name = "Spor", Slug = "spor" },
					new Category { Name = "Doğa", Slug = "doga" },
					new Category { Name = "Siyaset", Slug = "siyaset" }
				};

				context.Categories.AddRange(categories);
				context.SaveChanges();
			}
			if (!context.Users.Any())
			{
				context.Users.Add(new User { Name = "Admin", Email = "eren@hacker.com", Password = "admin", Phone = "053664444429", City = "Ankara" });
				context.SaveChanges();
			}
			if (!context.Posts.Any())
			{
				var posts = new Post[]
				{
					new Post { Title = "Amariga Bizi Kıskanmak", Content = "Dış minnakların oyunu bunlar, Bizi kıskanıyorlar", Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 1) },UserId=1},
					new Post { Title = "Spor ", Content = "Futbol", Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 2) },UserId=1},
					new Post { Title = "Doğa", Content = "Yaradan Yaratmış", Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 3) },UserId=1},
					new Post { Title = "Siyaset", Content = "Adam Kazandı.",Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 4) },UserId=1}
				};

				context.Posts.AddRange(posts);
				context.SaveChanges();
			}
			if (!context.Pages.Any())
			{
				var pages = new Page[]
				{
					new Page { Title = "Sayfa"}

				};

				context.Pages.AddRange(pages);
				context.SaveChanges();
			}

		}
	}
}
