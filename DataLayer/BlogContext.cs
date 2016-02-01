using DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(p => p.Id).Property(p => p.Title).HasMaxLength(150);

            modelBuilder.Entity<Post>().Property(p => p.Content).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class BlogDbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            base.Seed(context);

            new List<Blog>
            {
                new Blog { BloggerName = "Hanned", Title="First", DateCreated = DateTime.Now,
                    Posts = new List<Post> {new Post { Title="Answer", Content="Wrong" } } },
                new Blog { BloggerName = "Manori", Title="Second", DateCreated = DateTime.Now,
                    Posts = new List<Post>() {new Post { Title="Answer", Content="Right" } } }
            }.ForEach(b => context.Blogs.Add(b));
            //context.SaveChanges();
        }
    }
}
