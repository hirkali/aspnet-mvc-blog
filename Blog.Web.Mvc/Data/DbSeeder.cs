﻿using Blog.Web.Mvc.Data.Entity;

namespace Blog.Web.Mvc.Data
{
    public class DbSeeder 
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                // Kategorileri oluşturma
                var categories = new Category[]
                {
                    new Category { Name = "Teknoloji" },
                    new Category { Name = "Spor" },
                    new Category { Name = "Sağlık" },
                    new Category { Name = "Müzik" }
                };

                foreach (Category c in categories)
                {
                    context.Categories.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                // Yazıları oluşturma
                var posts = new Post[]
                {
                    new Post { Title = "Lorem Ipsum", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Id = 1 },
                    new Post { Title = "Spor Haberleri", Content = "Yerli ve yabancı spor haberleri...", Id = 2 },
                    new Post { Title = "Sağlık Haberleri", Content = "Yeni tedavi yöntemleri...", Id = 3 },
                    new Post { Title = "Müzik Dünyasından Haberler", Content = "Yeni albümler ve konserler hakkında güncel bilgiler...", Id = 4 }
                };

                foreach (Post p in posts)
                {
                    context.Posts.Add(p);
                }

                context.SaveChanges();
            }
        }
    }
}