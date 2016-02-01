using DataLayer;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateBlog();
        }

        private static void CreateBlog()
        {
            using (var context = new BlogContext())
            {
                context.Blogs.Add(new Blog { BloggerName = "Mannod", Title = "Code First Awesome" });
                context.SaveChanges();

            }
        }
    }
}
