using DataLayer;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BlogContext>());
            Database.SetInitializer(new BlogDbInitializer());

            CreateBlog();
            AddFirstPost();
            AddSecondPost();

        }

        private static void AddSecondPost()
        {
            using (var context = new BlogContext())
            {
                var blog = context.Blogs.Find(1);
                blog.Posts.Add(new Post { Title = "Second Post", Content = "Nice to see you again." });
                context.SaveChanges();
            }
        }

        private static void AddFirstPost()
        {
            using (var context = new BlogContext())
            {
                var blog = context.Blogs.Find(1);
                blog.Posts.Add(new Post { Title = "First Post", Content = "Hello, this is the first start." });
                context.SaveChanges();
            }
        }

        private static void CreateBlog()
        {
            using (var context = new BlogContext())
            {
                context.Blogs.Add(new Blog { BloggerName = "Mannod", Title = "Code First Awesome" , DateCreated = DateTime.Now });
                context.SaveChanges();

            }
        }
    }
}
