using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Blog
    {
        public Blog()
        {
            this.Posts = new List<Post>(); // when page load, Posts can be initialized, "this." can be skipped
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string BloggerName { get; set; }

        public List<Post> Posts { get; set; } // one to many
    }
}
